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

namespace AfterworldQuestManager.Views
{
    public partial class QuestsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public QuestsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}