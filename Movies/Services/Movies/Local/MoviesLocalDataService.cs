using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Movies.Models;                                                                         
using SQLite;

namespace Movies.Services.Movies.Local
{
    public class MoviesLocalDataService : IMoviesLocalDataService
    {
        private readonly SQLiteAsyncConnection _database;
        private string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "moviesapp.db3");

        public MoviesLocalDataService()
        {
            _database = new SQLiteAsyncConnection(_path);

            CreateTables();
        }

        private void CreateTables()
        {
            _database.CreateTableAsync<Movie>();
        }

        public async Task<IReadOnlyList<Movie>> GetMoviesAsync()
        {
            try
            {
                return await _database.Table<Movie>().ToListAsync();
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
                return await _database.InsertAllAsync(movies) > 0;
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
                return await _database.Table<Movie>().FirstOrDefaultAsync(x => x.Id == movieId);
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
                return await _database.DeleteAllAsync<Movie>() > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
