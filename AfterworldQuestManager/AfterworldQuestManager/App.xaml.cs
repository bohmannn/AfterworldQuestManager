using AfterworldQuestManager.Services;
using AfterworldQuestManager.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;

namespace AfterworldQuestManager
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
