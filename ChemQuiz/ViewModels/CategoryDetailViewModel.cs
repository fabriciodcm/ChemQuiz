using ChemQuiz.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ChemQuiz.ViewModels
{
    public class CategoryDetailViewModel : BaseViewModel
    {
        private ObservableCollection<Game> Games { get; set; }
        public IEnumerable<QuizGroup<char, Game>> GroupedGames { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CategoryDetailViewModel(Category category)
        {
            Games = new ObservableCollection<Game>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(category.CategoryId));
            LoadItemsCommand.Execute(category.CategoryId);
        }

        protected ObservableCollection<Game> getCategories(int CategoryID)
        {
            //Consome API
            //Mock de teste
            ObservableCollection<Game> games = new ObservableCollection<Game>();
            games.Add(new Game() { GameName = "Reações Ácido-Base", GameDescription = "Definições básicas de reações Ácido-Base." });
            games.Add(new Game() { GameName = "Química orgânica", GameDescription = "Química orgânica." });
            games.Add(new Game() { GameName = "Química inorgânica", GameDescription = "Química inorgânica." });
            return games;
        }

        async Task ExecuteLoadItemsCommand(int CategoryId)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Games.Clear();
                Games = getCategories(CategoryId);
                GroupedGames = ListGameGroups();
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
        public IEnumerable<QuizGroup<char, Game>> ListGameGroups(string filter = "")
        {
            IEnumerable<Game> filteredGames = this.Games;
            if (!String.IsNullOrEmpty(filter))
            {
                filteredGames = this.Games.Where(
                    x => x.GameName.ToLower().Contains(filter.ToLower())
                    || x.GameDescription.ToLower().Contains(filter.ToLower())
                );
            }

            //Agrupa pela primeira letra do nome
            return from game in filteredGames
                   orderby game.GameName
                   group game by game.GameName[0] into groups
                   select new QuizGroup<char, Game>(groups.Key, groups);
        }
    }
}
