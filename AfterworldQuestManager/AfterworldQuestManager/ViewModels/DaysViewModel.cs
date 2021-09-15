using AfterworldQuestManager.Models;
using AfterworldQuestManager.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;


namespace AfterworldQuestManager.ViewModels
{
    public class DaysViewModel : BaseViewModel
    {
        private Days _selectedItem;
        //public ObservableCollection<Days> Items { get; }
        //public Command LoadItemsCommand { get; }
        //public Command AddItemCommand { get; }
        //public Command<Days> ItemTapped { get; }

        public List<Days> Totals { get; set; }

        public DaysViewModel()
        {
            Title = "Дни по квестам";

            //Items = new ObservableCollection<Days>();
            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            //ItemTapped = new Command<Days>(OnItemSelected);
            //AddItemCommand = new Command(OnAddItem);

            DatabaseSingleton ds = DatabaseSingleton.GetInstance();

            ds.db.CreateTable<Days>();

            var days = ds.db.Table<Days>().ToList();

            Totals = days;
        }

        /*async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DaysDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
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
        }*/

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Days SelectedItem
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

        async void OnItemSelected(Days item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.Id)}={item.day}");
        }
    }
}