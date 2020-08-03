using MarvelApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelApp.Helpers
{
    public class MarvelAppDataBase
    {
        readonly SQLiteAsyncConnection database;

        public MarvelAppDataBase(string dbPath)
        {
            try
            {
                database = new SQLiteAsyncConnection(dbPath);
                database.CreateTableAsync<Charactters>();//Charactters


            }
            catch (Exception ex)
            {

            }
        }
        #region HeroeFavorite
        public async Task<Charactters> CheckFavorite(int id)
        {
            try
            {
                return await database.Table<Charactters>().Where(x => x.Id == id).FirstOrDefaultAsync();


            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public async Task<int> SaveFavorite(Charactters item)
        {
            return await database.InsertAsync(item);
        }
        public async Task<int> DeleteFavorite(Charactters item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<List<Charactters>> GetFavorites()
        {
            return await database.Table<Charactters>().ToListAsync();
        }
        #endregion
    }
}
