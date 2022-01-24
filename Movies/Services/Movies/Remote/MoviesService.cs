using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Movies.Models;
using Movies.Services.Request;

namespace Movies.Services.Movies.Remote
{
    public class MoviesService : IMoviesService
    {
        private readonly IRequestService _requestProvider;

        public MoviesService(IRequestService requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<SearchResponse<Movie>> GetPopularAsync(int pageNumber, string language)
        {
            try
            {
                string uri = $"{AppSettings.ApiUrl}movie/popular?api_key={AppSettings.ApiKey}&language={language}&page={pageNumber}";

                SearchResponse<Movie> response = await _requestProvider.GetAsync<SearchResponse<Movie>>(uri);

                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new SearchResponse<Movie>();
            }
        }

        public async Task<SearchResponse<Movie>> GetTopRatedAsync(int pageNumber, string language)
        {
            try
            {
                string uri = $"{AppSettings.ApiUrl}movie/top_rated?api_key={AppSettings.ApiKey}&language={language}&page={pageNumber}";

                SearchResponse<Movie> response = await _requestProvider.GetAsync<SearchResponse<Movie>>(uri);

                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new SearchResponse<Movie>();
            }
        }

        public async Task<Movie> FindByIdAsync(int movieId, string language)
        {
            try
            {
                string uri = $"{AppSettings.ApiUrl}movie/{movieId}?api_key={AppSettings.ApiKey}&language={language}";

                Movie response = await _requestProvider.GetAsync<Movie>(uri);

                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new Movie();
            }
        }
    }
}