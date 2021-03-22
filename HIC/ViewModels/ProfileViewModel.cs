using HIC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HIC.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private const string BaseURL = "https://jcihackathon.alwaysdata.net/public/api/";
        static HttpClient _client = new HttpClient();
        User user = new User();
        public User User { get { return user; } private set { SetProperty(ref user, value); } }
        public string nom;
        public string Nom { get { return nom; } private set { SetProperty(ref nom, value); } }
        public ProfileViewModel()
        {
            var b = Application.Current.Properties["token"].ToString();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Application.Current.Properties["token"].ToString());
        }

        public async Task Init()
        {
            var b = await _client.GetStringAsync(BaseURL + "user");
            User = JsonConvert.DeserializeObject<User>(b);
            Nom = user.Name + " " + user.LastName;
        }
    }
}
