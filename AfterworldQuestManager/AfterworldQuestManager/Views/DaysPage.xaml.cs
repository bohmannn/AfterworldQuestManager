using AfterworldQuestManager.Models;
using AfterworldQuestManager.ViewModels;
using AfterworldQuestManager.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AfterworldQuestManager;


namespace AfterworldQuestManager.Views
{
    public partial class DaysPage : ContentPage
    {
        DaysViewModel _viewModel;

        public DaysPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new DaysViewModel();

    
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

       

        
    }
}