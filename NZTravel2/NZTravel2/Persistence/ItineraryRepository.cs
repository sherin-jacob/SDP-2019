using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NZTravel2.Persistence
{
    public class ItineraryRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public ItineraryRepository()
        {
            _database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
            _database.CreateTableAsync<Itinerary>().Wait();
        }
        private List<Itinerary> _seedTodoList = new List<Itinerary>{};

        public async Task<List<Itinerary>> GetList()
        {
            return await _database.Table<Itinerary>().ToListAsync();
        }

        public Task DeleteItem(Itinerary itemToDelete)
        {
            return _database.DeleteAsync(itemToDelete);
        }

        public Task AddItem(Itinerary itemToAdd)
        {
            return _database.InsertAsync(itemToAdd);
        }
        public async Task<int> countAsync()
        {
            return await _database.Table<Itinerary>().CountAsync();
        }
    }
}
