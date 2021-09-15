using AfterworldQuestManager.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AfterworldQuestManager.ViewModels
{
    [QueryProperty(nameof(id), nameof(id))]
    public class ItemDetailViewModel : BaseViewModel
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

        public int Id
        {
            get => id;
            set
            {
                id = value;
                LoadItemId(value);
            }
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

        public async void LoadItemId(int itemId)
        {
            try
            {

                var item = await DataStore.GetItemAsync(itemId);

                id = item.id;
                desc = item.desc;
                reqSuccess = item.reqSuccess;
                reqFail = item.reqFail;
                activeTime = item.activeTime;
                pointsNeeded = item.pointsNeeded;
                xp = item.xp;
                gold = item.gold;
                jobTime = item.jobTime;
                other = item.other;
                popAdd = item.other;
                popDel = item.popDel;
                buildingId = item.buildingId;
                actorsRequired = item.actorsRequired;
                actorClassId = item.actorClassId;
                text = item.text;
                success = item.success;
                fail = item.fail;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
