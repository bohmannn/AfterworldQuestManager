using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using SQLite;
using System.Linq;

using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using AfterworldQuestManager.Models;

namespace AfterworldQuestManager.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string questsInDb;
        public string QuestsInDb
        {
            get => questsInDb;
            set => SetProperty(ref questsInDb, value);
        }

        public AboutViewModel()
        {
            Title = "Главная";
            QuestsInDb = "Квестов в базе: 0";
            LoadDbCommand = new Command(OnLoadClicked);
        }

        public ICommand LoadDbCommand { get; }


        private async void OnLoadClicked(object obj)
        {
            try
            {         
                FileData fileData = await CrossFilePicker.Current.PickFile();
                if (fileData == null)
                {
                    return; // user canceled file picking
                }

                DatabaseSingleton ds = DatabaseSingleton.GetInstance();
                ds.db = new SQLiteConnection(fileData.FilePath, SQLite.SQLiteOpenFlags.ReadWrite);
                //ds.db = new SQLiteConnection(fileData.FilePath + "ss", SQLite.SQLiteOpenFlags.Create);

                System.Console.WriteLine(fileData.FilePath);

                ds.db.CreateTable<Quests>();
                QuestsInDb = "Квестов в базе: " + ds.db.Table<Quests>().Count().ToString();


                var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.StorageWrite>();
                }


            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
            }

        }
    }
}