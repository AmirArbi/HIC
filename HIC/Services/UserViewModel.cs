using HIC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HIC.Services
{
    class UserViewModel
    {
        private const string URL = "https://jcihackathon.alwaysdata.net/public/api/login";
        static HttpClient _client = new HttpClient();
        public static async Task<HttpResponseMessage> LoginsAsync(string Username, string Password)
        {
            Login login = new Login
            {
                email = Username,
                password = Password
            };
            var content = JsonConvert.SerializeObject(login);
            var sContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage b = null;
            try
            {
                b = await _client.PostAsync(URL, sContent);
                Application.Current.Properties["token"] = b.Content.ReadAsStringAsync().Result.Substring(3);
            }
            catch (Exception ex)
            {
                if (b == null)
                {
                    b = new HttpResponseMessage();
                }
                b.StatusCode = HttpStatusCode.InternalServerError;
                b.ReasonPhrase = string.Format("RestHttpClient.SendRequest failed: {0}", ex);
            }
            return b;
        }
        public static HttpResponseMessage UpdateDetails()
        {

            return new HttpResponseMessage();
        }
    }
}
