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
    public class LeaderboardViewModel : BaseViewModel
    {
        public ObservableCollection<Ranking> Ranking { get; set; }

        public Command LoadItemsCommand { get; set; }

        public LeaderboardViewModel()
        {
            Ranking = new ObservableCollection<Ranking>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItemsCommand.Execute(null);
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Ranking.Clear();
                Ranking = getRanking();
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
        protected ObservableCollection<Ranking> getRanking()
        {
            //Consome API
            //Mock de teste
            ObservableCollection<Ranking> ranking = new ObservableCollection<Ranking>();
            ranking.Add(new Ranking()
            {
                User = new User(){
                    UserName = "João Paulo",
                    Avatar = new Avatar() {
                        AvatarName = "013-boy-16.png"
                    }
                },
                Rank = Rank.First,
                coins = 1200
            });
            ranking.Add(new Ranking()
            {
                User = new User()
                {
                    UserName = "Maria Clara",
                    Avatar = new Avatar()
                    {
                        AvatarName = "020-girl-4.png"
                    }
                },
                Rank = Rank.Second,
                coins = 755
            });
            ranking.Add(new Ranking()
            {
                User = new User()
                {
                    UserName = "Fabricio",
                    Avatar = new Avatar()
                    {
                        AvatarName = "027-boy-8.png"
                    }
                },
                Rank = Rank.Third,
                coins = 650
            });
            
            return ranking;
        }
    }
}
