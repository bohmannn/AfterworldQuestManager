using AfterworldQuestManager.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

using SQLite;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;

using Xamarin.Essentials;
using System.IO;

namespace AfterworldQuestManager.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            try
            {
                //var db = new SQLiteConnection(dbPath);
                FileData fileData = await CrossFilePicker.Current.PickFile();
                if (fileData == null)
                {
                    return; // user canceled file picking
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
            }
            //FilePicker.PickAsync();

        }
    }
}
