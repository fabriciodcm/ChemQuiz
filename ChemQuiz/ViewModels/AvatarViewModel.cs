using ChemQuiz.Models;
using ChemQuiz.Services;
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
                Avatars = await getAvatars();
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
        protected async Task<ObservableCollection<Avatar>> getAvatars()
        {
            ObservableCollection<Avatar> avatars;
            AvatarService service = new AvatarService();
            var list = await service.FindAll();
            avatars = new ObservableCollection<Avatar>(list);
            return avatars;
        }
    }
}

