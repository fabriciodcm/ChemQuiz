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
        public Command FilterItemsCommand { get; set; }

        string FilterParam;
        public string filterParam
        {
            get { return FilterParam; }
            set
            {
                FilterParam = value;
                OnPropertyChanged();
                FilterItemsCommand = new Command(async () => await ExecuteFilterItemsCommand(FilterParam));
                FilterItemsCommand.Execute(FilterParam);
                OnPropertyChanged(nameof(GroupedGames));

            }
        }

        public CategoryDetailViewModel(Category category)
        {
            Games = new ObservableCollection<Game>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(category.CategoryId));
            LoadItemsCommand.Execute(category.CategoryId);
        }

        protected ObservableCollection<Game> getCategoryGames(int CategoryID)
        {
            //Consome API
            //Mock de teste
            ObservableCollection<Game> games = new ObservableCollection<Game>();
            var levels = new List<Level>();
            levels.Add(new Level()
            {
                LevelNumber = 1,
                LevelLesson = "Utilizando-se da teoria ácido-base de Arrhenius (com íons positivos de hidrogênio e íons negativos de hidroxila liberados em meio aquoso), numa reação de neutralização (total ou parcial) há sempre formação de moléculas de água líquida. Exemplo : HX(aq) + YOH(aq) -> YX(aq) + H2O(l)",
                isFinished = false
            });
            levels.Add(new Level()
            {
                LevelNumber = 2,
                LevelLesson = "Utilizando-se da teoria ácido-base de Arrhenius (com íons positivos de hidrogênio e íons negativos de hidroxila liberados em meio aquoso), numa reação de neutralização (total ou parcial) há sempre formação de moléculas de água líquida. Exemplo : HX(aq) + YOH(aq) -> YX(aq) + H2O(l)",
                isFinished = false
            });
            games.Add(new Game()
            {
                GameName = "Reações Ácido-Base",
                GameDescription = "Definições básicas de reações Ácido-Base.",
                Levels = levels
            });
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
                Games = getCategoryGames(CategoryId);
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

        async Task ExecuteFilterItemsCommand(string filter)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                GroupedGames = ListGameGroups(filter);
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
            if (!String.IsNullOrEmpty(filter) && filter.Length >= 3)
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
