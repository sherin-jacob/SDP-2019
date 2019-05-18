using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NZTravel2.Persistence
{
    public class ItineraryRepository
    {
        private readonly SQLiteAsyncConnection _database;  // creates connection

        public ItineraryRepository()
        {
            _database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
            _database.CreateTableAsync<Itinerary>().Wait();
        }
        private List<Itinerary> _seedTodoList = new List<Itinerary>{};

        //gets items in database
        public async Task<List<Itinerary>> GetList()
        {
            return await _database.Table<Itinerary>().ToListAsync();
        }

        //deletes item in database
        public Task DeleteItem(Itinerary itemToDelete)
        {
            return _database.DeleteAsync(itemToDelete);
        }


        //adds item to database
        public Task AddItem(Itinerary itemToAdd)
        {
            return _database.InsertAsync(itemToAdd);
        }
        //counts number of items in database
        public async Task<int> countAsync()
        {
            return await _database.Table<Itinerary>().CountAsync();
        }
    }
}
