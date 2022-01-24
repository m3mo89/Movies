using System;
using System.Threading.Tasks;
using Movies.Models;

namespace Movies.Services.Movies
{
    public interface IMoviesService
    {
        Task<SearchResponse<Movie>> GetTopRatedAsync(int pageNumber, string language);

        Task<SearchResponse<Movie>> GetPopularAsync(int pageNumber, string language);

        Task<Movie> FindByIdAsync(int movieId, string language);
    }
}
