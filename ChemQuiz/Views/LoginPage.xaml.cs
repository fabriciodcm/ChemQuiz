using ChemQuiz.Models;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChemQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage() => InitializeComponent();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        //https://techcommunity.microsoft.com/t5/microsoft-mvp-award-program-blog/implementing-signin-and-signup-with-xamarin-forms-and-asp-net/ba-p/428586
        async void OnEntrarButtonClicked(object sender, EventArgs e)
        {
            try
            {
                
                var client = new HttpClient();
                var LoginModel = new
                {
                    Email = Email.Text,
                    Password = Password.Text,
                };
                var jsonObject = JsonConvert.SerializeObject(LoginModel);
                var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                var response = await client.PostAsync((Constants.URL + "Authenticate/login"), content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(result);
                    var accessToken = jwtDynamic.Value<string>("token");
                    DateTime expiration = jwtDynamic.Value<DateTime>("expiration");
                    var jsonUser = jwtDynamic.Value<object>("appuser");
                    var user = JsonConvert.DeserializeObject<User>(jsonUser.ToString());
                    
                    var jwt = accessToken;
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(jwt);

                    Session.loggedUser = user;
                    Session.accessToken = accessToken;
                    Session.sessionExpiretion = expiration;

                    Application.Current.MainPage = new MainPage();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("An error has occurred", "Exception message: " + ex.Message, "Dismiss");
            }
        }
    }
}