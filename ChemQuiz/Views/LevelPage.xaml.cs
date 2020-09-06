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
    public partial class LevelPage : ContentPage
    {
        LevelViewModel viewModel;
        public LevelPage(Game game)
        {
            InitializeComponent();

            BindingContext = viewModel = new LevelViewModel(game);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.UnlockedLevels.Count() == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async void Rank_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LeaderboardPage());
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var level = args.SelectedItem as Level;
            // Manually deselect item.
            LevelsListView.SelectedItem = null;
            if (level == null || level.LevelDescription.Contains("Bloqueado"))
                return;

            //Navega para a página dos cursos
            await Navigation.PushAsync(new QuizPage());
        }
    }
}