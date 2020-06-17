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
    public partial class CategoryDetailPage : ContentPage
    {
        CategoryDetailViewModel viewModel;
        public Category category { get; set; }
        public CategoryDetailPage(Category category)
        {
            this.category = category;

            InitializeComponent();

            BindingContext = viewModel = new CategoryDetailViewModel(this.category);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.GroupedGames.Count() == 0)
                viewModel.LoadItemsCommand.Execute(this.category.CategoryId);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var game = args.SelectedItem as Game;
            if (category == null)
                return;

            //Navega para a página dos cursos
            //await Navigation.PushAsync(new CategoryDetailPage(category));

            // Manually deselect item.
            GamesListView.SelectedItem = null;
        }
    }
}