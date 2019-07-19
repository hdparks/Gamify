using Gamify.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gamify.Data
{
    public class Database
    {
        readonly SQLite.SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLite.SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        //  USER ACCESS
        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            //  User.ID == 0 until database gives it an ID
            return user.ID == 0 ? _database.InsertAsync(user) : _database.UpdateAsync(user);            
        }

    }
}
