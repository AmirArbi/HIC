using HIC.Views.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HIC.Views.Doctor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Verification : ContentPage
    {
        public Verification()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool q = await DisplayAlert("Emargency", "Do you want to call the police", "Back", "Yes");
            if (q)
                App.Current.MainPage = new TabbedPage1();
            else
                Xamarin.Essentials.PhoneDialer.Open("197");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new TabbedPage2();
        }
    }
}