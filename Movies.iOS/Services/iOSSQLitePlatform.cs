using System;
using System.IO;
using Movies.Services.Database;
using SQLite;

namespace Movies.iOS.Services
{
    public class iOSSQLitePlatform : ISQLitePlatform
    {
        private string GetPath()
        {
            var dbName = "moviesapp.db3";
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
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
