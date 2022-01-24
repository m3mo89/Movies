using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.Models;
using Movies.Services.Movies.Local;
using Movies.Services.Movies.Remote;

namespace Movies.Services.Movies
{
    public class MoviesManager : IMoviesManager
    {
        private IMoviesService _moviesService;
        private IMoviesLocalDataService _moviesLocalDataService;

        public MoviesManager(IMoviesService moviesService, IMoviesLocalDataService moviesLocalDataService)
        {
            _moviesService = moviesService;
            _moviesLocalDataService = moviesLocalDataService;
        }

        public async Task<Movie> FindByIdAsync(int movieId)
        {
            var localData = await _moviesLocalDataService.FindMovieByIdAsync(movieId);

            if (localData != null)
            {
                return localData;
            }

            return new Movie();
        }

        public async Task<IReadOnlyList<Movie>> GetPopularAsync(int pageNumber, string language, bool forceRequest)
        {
            var localData = await _moviesLocalDataService.GetMoviesAsync();

            if (!localData.Any() || forceRequest)
            {
                var remoteData = await _moviesService.GetPopularAsync(pageNumber, language);

                if (remoteData?.Results != null)
                {
                    await _moviesLocalDataService.SaveAsync(remoteData.Results.ToList());

                    return remoteData.Results;
                }

                return new List<Movie>();
            }

            return localData;
        }

        public async Task<IReadOnlyList<Movie>> GetTopRatedAsync(int pageNumber, string language, bool forceRequest)
        {
            var localData = await _moviesLocalDataService.GetMoviesAsync();

            if (!localData.Any() || forceRequest)
            {
                var remoteData = await _moviesService.GetTopRatedAsync(pageNumber, language);

                if (remoteData?.Results != null)
                {
                    await _moviesLocalDataService.SaveAsync(remoteData.Results.ToList());

                    return remoteData.Results;
                }

                return new List<Movie>();
            }

            return localData;
        }

        public async Task<bool> DeleteAsync()
        {
            return await _moviesLocalDataService.DeleteAsync();
        }
    }
}