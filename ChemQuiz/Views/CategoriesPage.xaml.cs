using ChemQuiz.Models;
using ChemQuiz.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChemQuiz.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        CategoryViewModel viewModel;
        public CategoriesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CategoryViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Categories.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var category = args.SelectedItem as Category;
            if (category == null)
                return;

            //Navega para a página dos cursos
            await Navigation.PushAsync(new CategoryDetailPage(category));

            // Manually deselect item.
            CategoriesView.SelectedItem = null;
        }
    }
}