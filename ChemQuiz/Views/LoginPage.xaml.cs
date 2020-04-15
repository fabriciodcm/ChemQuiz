using ChemQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChemQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnEntrarButtonClicked(object sender, EventArgs e) {
            App.Current.MainPage = new MainPage();
            await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new ItemsPage());
        }
    }
}