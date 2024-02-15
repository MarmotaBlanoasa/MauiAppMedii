using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace MauiAppMedii.Data
{
    internal class EventsTrakerDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public EventsTrakerDatabase(string dbPath) { 
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Models.Event>().Wait();
            _database.CreateTableAsync<Models.Schedule>().Wait();
        }
        public Task<List<Models.Event>> GetEventsAsync()
        {
            return _database.Table<Models.Event>().ToListAsync();
        }
        public Task<Models.Event> GetEventAndSchedulesAsync(int id)
        {
            return _database.Table<Models.Event>()
                .Where(i => i.EventId == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveEventAsync(Models.Event @event)
        {
            if (@event.EventId != 0)
            {
                return _database.UpdateAsync(@event);
            }
            else
            {
                return _database.InsertAsync(@event);
            }
        }
        public Task<int> DeleteEventAsync(Models.Event @event)
        {
            return _database.DeleteAsync(@event);
        }
        public Task<List<Models.Schedule>> GetAllSchedulesByEventIDAsync(int id)
        {
            return _database.Table<Models.Schedule>()
                .Where(i => i.EventId == id).ToListAsync();
        }

    }
}
