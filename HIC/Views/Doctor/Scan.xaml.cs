using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        private async void scanner_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if(result.BarcodeFormat == ZXing.BarcodeFormat.QR_CODE)
                {
                    scanner.IsScanning = false;
                    await DisplayAlert("Success", result.Text, "Done");
                    scanner.IsScanning = true;
                }

            });
        }
    }
}