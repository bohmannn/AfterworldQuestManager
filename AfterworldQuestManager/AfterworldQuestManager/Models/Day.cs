using System;
using SQLite;

namespace AfterworldQuestManager.Models
{
    public class Days
    {
        [PrimaryKey, AutoIncrement]
        public int day { get; set; }
        public string quests { get; set; }
    }
}