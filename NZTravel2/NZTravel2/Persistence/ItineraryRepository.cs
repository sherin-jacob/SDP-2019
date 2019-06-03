using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NZTravel2.Persistence
{
    public class ItineraryRepository
    {
        //used to make a connection to the database
        private readonly SQLiteAsyncConnection _database;

        public ItineraryRepository()
        {
            _database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
            //Creates tables in the database
            _database.CreateTableAsync<Itinerary>().Wait(); 
            _database.CreateTableAsync<ItineraryHome>().Wait();
        }

        //sets the default lists
        private List<Itinerary> _seedTodoList = new List<Itinerary>{}; 
        private List<ItineraryHome> _seedToDoList2 = new List<ItineraryHome> {};

        //gets items in a table
        public async Task<List<Itinerary>> GetList()
        {
            return await _database.Table<Itinerary>().ToListAsync(); //gets list of items from database
        }
        public async Task<List<ItineraryHome>> GetItineraries()
        {
            return await _database.Table<ItineraryHome>().ToListAsync();
        }

        //deletes items in a table
        public Task DeleteItem(Itinerary itemToDelete)
        {
            return _database.DeleteAsync(itemToDelete); 
        }
        public Task DeleteItinerary(ItineraryHome itemToDelete)
        {
            return _database.DeleteAsync(itemToDelete); 
        }

        //adds item to a table
        public Task AddItem(Itinerary itemToAdd)
        {
            return _database.InsertAsync(itemToAdd); 
        }
        public Task AddItinerary(ItineraryHome itemToAdd)
        {
            return _database.InsertAsync(itemToAdd);
        }

        // Returns number of rows in a table
        public async Task<int> countAsync()
        {
            return await _database.Table<Itinerary>().CountAsync();
        }
    }
}
