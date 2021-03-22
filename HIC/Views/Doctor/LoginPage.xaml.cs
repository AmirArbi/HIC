using HIC.ViewModels;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            InitializeComponent();
            vm.Success += () => Application.Current.MainPage = new TabbedPage1();
            vm.Echec += (code) => DisplayAlert("Erreur", "Nous ne pourrons vous connectez pour le moment à cause de " + code, "Back");
            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }
    }
}