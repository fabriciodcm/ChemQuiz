using ChemQuiz.Models;
using ChemQuiz.ViewModels;
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
    public partial class AvatarPage : ContentPage
    {
        AvatarViewModel viewModel;
        public AvatarPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new AvatarViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Avatars.Count() == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var avatar = args.SelectedItem as Avatar;
            // Manually deselect item.
            AvatarsListView.SelectedItem = null;
            if (avatar == null )
                return;

            //Navega para a página dos cursos
            await Navigation.PushAsync(new QuizPage());
        }
    }
}