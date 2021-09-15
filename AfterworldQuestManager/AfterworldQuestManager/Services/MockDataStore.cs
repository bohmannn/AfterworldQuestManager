using AfterworldQuestManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterworldQuestManager.Services
{
    public class MockDataStore : IDataStore<Quests>
    {
        readonly List<Quests> quests;

        public MockDataStore()
        {
            quests = new List<Quests>()
            {
                new Quests { id = 1 },

            };
        }

        public async Task<bool> AddItemAsync(Quests item)
        {
            quests.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Quests item)
        {
            var oldItem = quests.Where((Quests arg) => arg.id == item.id).FirstOrDefault();
            quests.Remove(oldItem);
            quests.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = quests.Where((Quests arg) => arg.id == id).FirstOrDefault();
            quests.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Quests> GetItemAsync(int id)
        {
            return await Task.FromResult(quests.FirstOrDefault(s => s.id == id));
        }

        public async Task<IEnumerable<Quests>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(quests);
        }
    }
}