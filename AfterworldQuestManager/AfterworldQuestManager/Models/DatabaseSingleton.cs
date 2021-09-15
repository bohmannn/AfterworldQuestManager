using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AfterworldQuestManager
{
    class DatabaseSingleton
    {
        public SQLiteConnection db;

        private DatabaseSingleton() { }

        private static DatabaseSingleton _instance;

        public static DatabaseSingleton GetInstance()
        {      
            if (_instance == null)
            {
                _instance = new DatabaseSingleton();

            }
            return _instance;
        }

        // Наконец, любой одиночка должен содержать некоторую бизнес-логику,
        // которая может быть выполнена на его экземпляре.
    }
}
