using ChemQuiz.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
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
            try
            {
                // Look for existing account
                /* IEnumerable<IAccount> accounts = await App.AuthenticationClient.GetAccountsAsync();

                 AuthenticationResult result = await App.AuthenticationClient
                     .AcquireTokenSilent(Constants.Scopes, accounts.FirstOrDefault())
                     .ExecuteAsync();

                 var jwt = result.IdToken;
                 var handler = new JwtSecurityTokenHandler();
                 var token = handler.ReadJwtToken(jwt);

                 Constants.LoggedUser = new User()
                 {
                     UserId = token.Claims.ToArray()[8].Value,
                     Name = token.Claims.ToArray()[9].Value,
                     FamilyName = token.Claims.ToArray()[10].Value,
                     Email = token.Claims.ToArray()[11].Value,
                     Coins = 200
                 };

                 Application.Current.MainPage = new MainPage(result);
                 await (Application.Current.MainPage as MasterDetailPage)
                     .Detail.Navigation.PushAsync(new ItemsPage()); */
            }
            catch
            {
                // Do nothing - the user isn't logged in
            }
            base.OnAppearing();
        }

        async void OnEntrarButtonClicked(object sender, EventArgs e)
        {
            AuthenticationResult result;
            try
            {
                result = await App.AuthenticationClient
                    .AcquireTokenInteractive(Constants.Scopes)
                    .WithPrompt(Prompt.SelectAccount)
                    .WithParentActivityOrWindow(App.UIParent)
                    .ExecuteAsync();

                var jwt = result.IdToken;
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwt);
                #region Test api authentication
                try {
                    var baseAddr = new Uri("https://chemquizapi.azurewebsites.net/");
                    var client = new HttpClient { BaseAddress = baseAddr };

                    var reviewUri = new Uri(baseAddr, "api/item");

                    var request = new HttpRequestMessage(HttpMethod.Get, reviewUri);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);

                    var response = await client.SendAsync(request);
                    //linha abaixo gera erro caso nao retorne na faixa 400
                    //response.EnsureSuccessStatusCode();

                    var reviewJson = await response.Content.ReadAsStringAsync();

                    //await DisplayAlert("Alert", reviewJson, "OK");

                }
                catch (Exception ex) {
                    Debug.WriteLine(ex);
                }

                #endregion

                Constants.LoggedUser = new User() { 
                    AuthId = token.Claims.ToArray()[8].Value,
                    Name = token.Claims.ToArray()[9].Value,
                    FamilyName = token.Claims.ToArray()[10].Value,
                    Email = token.Claims.ToArray()[11].Value,
                    Coins = 200
                };

                Application.Current.MainPage = new MainPage(result);
                await (Application.Current.MainPage as MasterDetailPage)
                    .Detail.Navigation.PushAsync(new ItemsPage());
            }
            catch (MsalException ex)
            {
                if (ex.Message != null && ex.Message.Contains("AADB2C90118"))
                {
                    result = await OnForgotPassword();
                    //await Navigation.PushAsync(new MainPage(result));
                }
                else if (ex.ErrorCode != "authentication_canceled")
                {
                    await DisplayAlert("An error has occurred", "Exception message: " + ex.Message, "Dismiss");
                }
            }
        }

        async void OnEntrarTesteButtonClicked(object sender, EventArgs e) {
            Application.Current.MainPage = new MainPage(null);
            //await (Application.Current.MainPage as MasterDetailPage)
            //    .Detail.Navigation.PushAsync(new ItemsPage());
        }
        async Task<AuthenticationResult> OnForgotPassword()
        {
            try
            {
                return await App.AuthenticationClient
                    .AcquireTokenInteractive(Constants.Scopes)
                    .WithPrompt(Prompt.SelectAccount)
                    .WithParentActivityOrWindow(App.UIParent)
                    .WithB2CAuthority(Constants.AuthorityPasswordReset)
                    .ExecuteAsync();
            }
            catch (MsalException)
            {
                // Do nothing - ErrorCode will be displayed in OnLoginButtonClicked
                return null;
            }
        }
    }
}