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
    public class AvatarViewModel : BaseViewModel
    {
        public ObservableCollection<Avatar> Avatars { get; set; }
        public Command LoadItemsCommand { get; set; }

        public AvatarViewModel()
        {
            Avatars = new ObservableCollection<Avatar>();
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
                Avatars.Clear();
                Avatars = getAvatars();
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
        protected ObservableCollection<Avatar> getAvatars()
        {
            //Consome API
            //Mock de teste
            ObservableCollection<Avatar> avatars = new ObservableCollection<Avatar>();
            int cont = 1;
            avatars.Add(new Avatar() {
                IdAvatar = cont++,
                Name = "013-boy-16.png",
                Price = 200
            });
            avatars.Add(new Avatar()
            {
                IdAvatar = cont++,
                Name = "020-girl-4.png",
                Price = 200
            });
            avatars.Add(new Avatar()
            {
                IdAvatar = cont++,
                Name = "027-boy-8.png",
                Price = 200
            });
            avatars.Add(new Avatar()
            {
                IdAvatar = cont++,
                Name = "028-girl-3.png",
                Price = 200
            });
            avatars.Add(new Avatar()
            {
                IdAvatar = cont++,
                Name = "031-girl-2.png",
                Price = 200
            });
            avatars.Add(new Avatar()
            {
                IdAvatar = cont++,
                Name = "035-boy-6.png",
                Price = 200
            });
            avatars.Add(new Avatar()
            {
                IdAvatar = cont++,
                Name = "037-girl-1.png",
                Price = 200
            });
            avatars.Add(new Avatar()
            {
                IdAvatar = cont++,
                Name = "038-athlete.png",
                Price = 200
            });
            avatars.Add(new Avatar()
            {
                IdAvatar = cont++,
                Name = "040-boy-5.png",
                Price = 200
            });
            avatars.Add(new Avatar()
            {
                IdAvatar = cont++,
                Name = "049-boy-1.png",
                Price = 200
            });
            return avatars;
        }
    }
}

