using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Models;

namespace Movies.Services.Movies
{
    public interface IMoviesManager
    {
        Task<IReadOnlyList<Movie>> GetTopRatedAsync(int pageNumber, string language, bool forceRequest);

        Task<IReadOnlyList<Movie>> GetPopularAsync(int pageNumber, string language, bool forceRequest);

        Task<Movie> FindByIdAsync(int movieId);

        Task<bool> DeleteAsync();
    }
}
