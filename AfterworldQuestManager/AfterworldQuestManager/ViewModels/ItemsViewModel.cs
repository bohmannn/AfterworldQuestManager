using AfterworldQuestManager.Models;
using AfterworldQuestManager.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AfterworldQuestManager.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Quests _selectedItem;

        public ObservableCollection<Quests> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Quests> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Квесты";
            Items = new ObservableCollection<Quests>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Quests>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);


            DatabaseSingleton ds = DatabaseSingleton.GetInstance();

           /* var quests = ds.db.Table<Quests>().ToList();


            foreach (var item in quests)
            {
                Items.Add(item);
            }*/

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                DatabaseSingleton ds = DatabaseSingleton.GetInstance();

                var quests = ds.db.Table<Quests>().ToList();

                Items.Clear();

                foreach (var item in quests)
                {
                    Items.Add(item);
                }
                

                /*Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }*/
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Quests SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Quests item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.Id)}={item.id}");
        }
    }
}