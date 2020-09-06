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
    public partial class LeaderboardPage : ContentPage
    {
        LeaderboardViewModel viewModel;
        
        public LeaderboardPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LeaderboardViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Ranking.Count() == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}