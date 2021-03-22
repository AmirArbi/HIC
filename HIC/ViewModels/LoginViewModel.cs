using HIC.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HIC.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Action Success;
        public Action<string> Echec;
        bool loading = false;
        public bool Loading { get { return loading; } private set { SetProperty(ref loading, value); } }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public async void OnSubmit()
        {
            Loading = true;
            var b = await UserViewModel.LoginsAsync(Email, Password);
            if (b.StatusCode == HttpStatusCode.OK)
            {
                Success();
            }
            else
            {
                Echec(b.ReasonPhrase);
            }
            Loading = false;
        }
    }
}
