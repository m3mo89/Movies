using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Movies.Models;

namespace Movies.Services.LocalData
{
    public class MoviesLocalDataService : IMoviesLocalDataService
    {
        private readonly ISQLitePlatform _database;

        public MoviesLocalDataService(ISQLitePlatform platform)
        {
            _database = platform;
            var con = _database.GetConnection();
            con.CreateTable<Movie>();
            con.Close();
        }

        public async Task<IReadOnlyList<Movie>> GetMoviesAsync()
        {
            try
            {
                return await _database.GetConnectionAsync().Table<Movie>().ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new List<Movie>();
            }
        }

        public async Task<bool> SaveAsync(List<Movie> movies)
        {
            try
            {
                return await _database.GetConnectionAsync().InsertAllAsync(movies) > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<Movie> FindMovieByIdAsync(int movieId)
        {
            try
            {
                return await _database.GetConnectionAsync().Table<Movie>().FirstOrDefaultAsync(x => x.Id == movieId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new Movie();
            }
        }

        public async Task<bool> DeleteAsync()
        {
            try
            {
                return await _database.GetConnectionAsync().DeleteAllAsync<Movie>() > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
