using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Models;

namespace Movies.Services.LocalData
{
    public interface IMoviesLocalDataService
    {
        Task<IReadOnlyList<Movie>> GetMoviesAsync();
        Task<bool> SaveAsync(List<Movie> movies);
        Task<Movie> FindMovieByIdAsync(int movieId);
        Task<bool> DeleteAsync();
    }
}
