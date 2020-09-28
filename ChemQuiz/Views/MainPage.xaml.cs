using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ChemQuiz.Models;
using Microsoft.Identity.Client;
using ChemQuiz.Services;

namespace ChemQuiz.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        AuthenticationResult authenticationResult;
        public MainPage(AuthenticationResult authenticationResult)
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);

            this.authenticationResult = authenticationResult;
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Play:
                        MenuPages.Add(id, new NavigationPage(new CategoriesPage()));
                        break;
                    case (int)MenuItemType.Avatar:
                        MenuPages.Add(id, new NavigationPage(new AvatarPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }

        protected override async void OnAppearing() 
        {
            UserService userService = new UserService(authenticationResult);

            User user = await userService.FindByAuthID(Constants.LoggedUser.AuthId);

            Constants.LoggedUser.Coins = user.Coins;
        }
    }
}