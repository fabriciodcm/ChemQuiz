using ChemQuiz.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChemQuiz.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CategoryViewModel()
        {
            Title = "Jogar";
            Categories = new ObservableCollection<Category>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Categories.Clear();
                //var items = await DataStore.GetItemsAsync(true);Função paraconsultar categorias na API
                Categories.Add(new Category()
                {
                    CategoryName = "Química",
                    CategoryDescription = "Estudo das reações químicas",
                    CategoryId = 1
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
