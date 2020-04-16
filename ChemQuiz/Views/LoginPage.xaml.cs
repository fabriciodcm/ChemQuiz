using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChemQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage() => InitializeComponent();

        async void OnEntrarButtonClicked(object sender, EventArgs e) {
            Application.Current.MainPage = new MainPage();
            await (Application.Current.MainPage as MasterDetailPage)
                .Detail.Navigation.PushAsync(new ItemsPage());
        }
    }
}