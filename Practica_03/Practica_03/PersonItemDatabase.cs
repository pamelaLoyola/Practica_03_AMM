using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practica_03
{
    public class PersonItemDatabase
    {

        readonly SQLiteAsyncConnection database;

        public PersonItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<PersonItem>().Wait();
        }

        public Task<List<PersonItem>> GetItemsAsync()
        {
            return database.Table<PersonItem>().ToListAsync();
        }

        public Task<List<PersonItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<PersonItem>("SELECT * FROM [PersonItem] WHERE [Done] = 0");
        }

        public Task<PersonItem> GetItemAsync(int id)
        {
            return database.Table<PersonItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(PersonItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }       

        public Task<int> DeleteItemAsync(PersonItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}

