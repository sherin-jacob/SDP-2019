using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NZTravel2.Persistence
{
    public class ItineraryRepository
    {
        private readonly SQLiteAsyncConnection _database; //used to make a connection to the database

        public ItineraryRepository()
        {
            _database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
            _database.CreateTableAsync<Itinerary>().Wait(); //Creates a table in the itinerarys
        }
        private List<Itinerary> _seedTodoList = new List<Itinerary>{}; // sets the default list

        public async Task<List<Itinerary>> GetList()
        {
            return await _database.Table<Itinerary>().ToListAsync(); //gets list of items from database
        }

        public Task DeleteItem(Itinerary itemToDelete)
        {
            return _database.DeleteAsync(itemToDelete); //Deletes item from database
        }

        public Task AddItem(Itinerary itemToAdd)
        {
            return _database.InsertAsync(itemToAdd); //Adds item to database
        }
        public async Task<int> countAsync()
        {
            return await _database.Table<Itinerary>().CountAsync();// Returns number of rows in the database
        }
    }
}
