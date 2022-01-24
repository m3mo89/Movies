using System;
using System.IO;
using Movies.Services.Database;
using SQLite;

namespace Movies.Droid.Services
{
    public class AndroidSQLitePlatform : ISQLitePlatform
    {
        private string GetPath()
        {
            var dbName = "moviesapp.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return path;
        }
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetPath());
        }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            return new SQLiteAsyncConnection(GetPath());
        }
    }
}
