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
                    Name = "João Paulo",
                    Avatar = new Avatar() {
                        Name = "013-boy-16.png"
                    }
                },
                Rank = Rank.First,
            });
            ranking.Add(new Ranking()
            {
                User = new User()
                {
                    Name = "Maria Clara",
                    Avatar = new Avatar()
                    {
                        Name = "020-girl-4.png"
                    }
                },
                Rank = Rank.Second,
            });
            ranking.Add(new Ranking()
            {
                User = new User()
                {
                    Name = "Fabricio",
                    Avatar = new Avatar()
                    {
                        Name = "027-boy-8.png"
                    }
                },
                Rank = Rank.Third,
            });
            
            return ranking;
        }
    }
}
