using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VinylVault.Data
{
    public class VinylVaultDatabase
    {

        readonly SQLiteAsyncConnection database;



        public VinylVaultDatabase(string dbPath)
        {

            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<AlbumModel>().Wait();
        }




        #region ALBUM
        public async Task<List<AlbumModel>> GetAlbumsAsync()
        {
            return await database.Table<AlbumModel>().ToListAsync();
        }



        public async Task<int> ClearAlbums()
        {
            await database.ExecuteScalarAsync<AlbumModel>("DELETE FROM [AlbumModel]");
            int ret = 1;
            return ret;

        }

        public async Task<int> InsertAlbum(AlbumModel am)
        {
            await database.InsertAsync(am);
            int ret = 1;
            return ret;
        }


        public async Task<int> DeleteAlbum(AlbumModel am)
        {
            await database.ExecuteScalarAsync<AlbumModel>("DELETE FROM [AlbumModel] WHERE TITLE = ?",am.Title);
            int ret = 1;
            return ret;
        }

        public async Task<int> UpdateAlbum(AlbumModel am)
        {
            await database.ExecuteScalarAsync<AlbumModel>("UPDATE [AlbumModel] SET ARTIST = ?, THUMB = ?, GENRE = ?, LOCATION = ? WHERE TITLE = ?", am.Artist, am.Thumb, am.Genre, am.Location, am.Title);
            int ret = 1;
            return ret;
        }

        #endregion



    }
}
