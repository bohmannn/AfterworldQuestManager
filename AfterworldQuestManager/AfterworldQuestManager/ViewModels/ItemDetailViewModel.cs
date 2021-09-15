using AfterworldQuestManager.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AfterworldQuestManager.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {

        private string itemId;
        private string id;
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

        public string SaveCommandText;


        public string ItemId
        {
            get => itemId;
            set
            {

                itemId = value;
                LoadItemId(value);
            }
        }

        public string Id
        {
            get => id;
            set => SetProperty(ref id, value);
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

        public async void LoadItemId(string itemId)
        {

            SaveCommandText = "Изменить";


            try
            {
                DatabaseSingleton ds = DatabaseSingleton.GetInstance();
                var qs = ds.db.Table<Quests>().ToList();

                System.Console.WriteLine("Getting id : " + (Convert.ToInt32(itemId) - 1).ToString());

                var item = qs[Convert.ToInt32(itemId)-1];
                //var item = await DataStore.GetItemAsync(itemId);

                Id = item.id.ToString();
                Desc = item.desc;
                ReqSuccess = item.reqSuccess;
                ReqFail = item.reqFail;
                ActiveTime = item.activeTime;
                PointsNeeded = item.pointsNeeded;
                Xp = item.xp;
                Gold = item.gold;
                JobTime = item.jobTime;
                Other = item.other;
                PopAdd = item.other;
                PopDel = item.popDel;
                BuildingId = item.buildingId;
                ActorsRequired = item.actorsRequired;
                ActorClassId = item.actorClassId;
                Text = item.text;
                Success = item.success;
                Fail = item.fail;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
