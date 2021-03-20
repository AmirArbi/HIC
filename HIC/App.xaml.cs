using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HIC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.Doctor.History();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
