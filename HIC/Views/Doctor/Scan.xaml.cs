using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using HIC.Views.Patient;

namespace HIC.Views.Doctor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Scan : ContentPage
    {
        public Scan()
        {
            InitializeComponent();
            
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            Rotate();
            base.OnSizeAllocated(width, height);
        }
        void Rotate()
        {
            if(Height < Width)
            {
                stack.Orientation = StackOrientation.Horizontal;
            }
            else
            {
                stack.Orientation = StackOrientation.Vertical;
            }
        }

        private void scanner_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if(result.BarcodeFormat == ZXing.BarcodeFormat.QR_CODE)
                {
                    Invert();
                }

            });
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var request = new AuthenticationRequestConfiguration("Verify your identity", "We need to verify if you are the right person to access the data");
            var finger = await CrossFingerprint.Current.AuthenticateAsync(request);
            if (finger.Authenticated)
            {
                App.Current.MainPage = new Verification();
            }
            else
            {
                await DisplayAlert("Error", finger.ErrorMessage, "Done");
            }

        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Invert();
        }
        void Invert()
        {
            verification.IsVisible = !verification.IsVisible;
            scanner.IsScanning = !scanner.IsScanning;
        }

        private void OutlinedEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if((sender as Entry).Text == "123456")
                App.Current.MainPage = new Verification();
        }
    }
}