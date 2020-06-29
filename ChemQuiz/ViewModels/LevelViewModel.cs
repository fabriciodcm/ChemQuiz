using ChemQuiz.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChemQuiz.ViewModels
{
    public class LevelViewModel : BaseViewModel
    {
        public ObservableCollection<Level> UnlockedLevels { get; set; }
        private Game game { get; set; }
        public Command LoadItemsCommand { get; set; }
        public LevelViewModel(Game game)
        {
            this.game = game;
            UnlockedLevels = new ObservableCollection<Level>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                UnlockedLevels.Clear();
                int lastLevel = game.Levels.Select(x => x.LevelNumber).Max();
                foreach (var level in game.Levels) {
                    level.LevelDescription = "Level " + level.LevelNumber;
                    level.LevelIcon = "level" + level.LevelNumber + ".png";
                    UnlockedLevels.Add(level);
                    if (!level.isFinished && level.LevelNumber < lastLevel) {
                        var lockedLevel = new Level() {
                            LevelDescription = "Bloqueado",
                            LevelIcon = "lockedlevel.png",
                        };
                        UnlockedLevels.Add(lockedLevel);
                        break;
                    }
                }
                
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
