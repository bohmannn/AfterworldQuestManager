using AfterworldQuestManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AfterworldQuestManager.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private int id;
        private string desc;
        private string reqSuccess;
        private string reqFail;
        private int activeTime;
        private int pointsNeeded;
        private int xp;
        private int gold;
        private int jobTime;
        private int other;
        private int popAdd;
        private int popDel;
        private int buildingId;
        private string actorsRequired;
        private int actorClassId;
        private string text;
        private string success;
        private string fail;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(actorsRequired)
                && !String.IsNullOrWhiteSpace(desc);
        }

        public string Desc
        {
            get => desc;
            set => SetProperty(ref desc, value);
        }
        public string ReqSuccess
        {
            get => reqSuccess;
            set => SetProperty(ref reqSuccess, value);
        }
        public string ReqFail
        {
            get => reqSuccess;
            set => SetProperty(ref reqFail, value);
        }
        public int ActiveTime
        {
            get => activeTime;
            set => SetProperty(ref activeTime, value);
        }
        public int PointsNeeded
        {
            get => pointsNeeded;
            set => SetProperty(ref pointsNeeded, value);
        }
        public int Xp
        {
            get => xp;
            set => SetProperty(ref xp, value);
        }
        public int Gold
        {
            get => gold;
            set => SetProperty(ref gold, value);
        }
        public int JobTime
        {
            get => jobTime;
            set => SetProperty(ref jobTime, value);
        }
        public int Other
        {
            get => other;
            set => SetProperty(ref other, value);
        }
        public int PopAdd
        {
            get => popAdd;
            set => SetProperty(ref popAdd, value);
        }
        public int PopDel
        {
            get => popDel;
            set => SetProperty(ref popDel, value);
        }
        public int BuildingId
        {
            get => buildingId;
            set => SetProperty(ref buildingId, value);
        }
        public string ActorsRequired
        {
            get => actorsRequired;
            set => SetProperty(ref actorsRequired, value);
        }
        public int ActorClassId
        {
            get => actorClassId;
            set => SetProperty(ref actorClassId, value);
        }
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public string Success
        {
            get => success;
            set => SetProperty(ref success, value);
        }
        public string Fail
        {
            get => fail;
            set => SetProperty(ref fail, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Quests newItem = new Quests()
            {
                id = 4,
                desc = Desc,
                reqSuccess = ReqSuccess,
                reqFail = ReqFail,
                activeTime = ActiveTime,
                pointsNeeded = PointsNeeded,
                xp = Xp,
                gold = Gold,
                jobTime = JobTime,
                other = Other,
                popAdd = Other,
                popDel = PopDel,
                buildingId = BuildingId,
                actorsRequired = ActorsRequired,
                actorClassId = ActorClassId,
                text = Text,
                success = Success,
                fail = Fail
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
