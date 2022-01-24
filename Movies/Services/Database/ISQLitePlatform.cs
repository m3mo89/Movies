using System;
using SQLite;

namespace Movies.Services.Database
{
    public interface ISQLitePlatform
    {
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetConnectionAsync();
    }
}
