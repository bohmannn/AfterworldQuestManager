using AfterworldQuestManager.Models;
using AfterworldQuestManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfterworldQuestManager.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Quests Quest { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}