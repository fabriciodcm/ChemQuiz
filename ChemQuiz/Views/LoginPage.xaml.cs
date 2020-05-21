﻿using ChemQuiz.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
                //IEnumerable<IAccount> accounts = await App.AuthenticationClient.GetAccountsAsync();

                //AuthenticationResult result = await App.AuthenticationClient
                //    .AcquireTokenSilent(Constants.Scopes, accounts.FirstOrDefault())
                //    .ExecuteAsync();

                //await Navigation.PushAsync(new MainPage(result));
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

                Constants.LoggedUser = new User() { 
                    UserId = token.Claims.ToArray()[8].Value,
                    Name = token.Claims.ToArray()[9].Value,
                    FamilyName = token.Claims.ToArray()[10].Value,
                    Email = token.Claims.ToArray()[11].Value,
                };
                await Navigation.PushAsync(new MainPage(result));
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