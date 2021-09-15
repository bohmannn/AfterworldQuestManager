using System;

namespace AfterworldQuestManager.Models
{
    public class Quests
    {
        public int id { get; set; }
        public string desc { get; set; }
        public string reqSuccess { get; set; }
        public string reqFail { get; set; }
        public int activeTime { get; set; }
        public int pointsNeeded { get; set; }
        public int xp { get; set; }
        public int gold { get; set; }
        public int jobTime { get; set; }
        public int other { get; set; }
        public int popAdd { get; set; }
        public int popDel { get; set; }
        public int buildingId { get; set; }
        public string actorsRequired { get; set; }
        public int actorClassId { get; set; }
        public string text { get; set; }
        public string success { get; set; }
        public string fail { get; set; }
    }
}