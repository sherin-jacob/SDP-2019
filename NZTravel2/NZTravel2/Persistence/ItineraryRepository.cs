
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

        private List<Itinerary> _seedTodoList = new List<Itinerary>
        {
            new Itinerary { Title = "Create First Todo"},
            new Itinerary { Title = "Run a Marathon"},
            new Itinerary { Title = "Create TodoXamarinForms blog post"},
        };

        public async Task<List<Itinerary>> GetList()
        {
            return await _database.Table<Itinerary>().ToListAsync();
        }

        public Task DeleteItem(Itinerary itemToDelete)
        {
            return _database.DeleteAsync(itemToDelete);
        }

        public Task ChangeItemIsCompleted(Itinerary itemToChange)
        {
            itemToChange.IsCompleted = !itemToChange.IsCompleted;
            return _database.UpdateAsync(itemToChange);
        }

        public Task AddItem(Itinerary itemToAdd)
        {
            return _database.InsertAsync(itemToAdd);
        }
    }
}