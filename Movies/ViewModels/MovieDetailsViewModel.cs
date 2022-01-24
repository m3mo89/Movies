using System;
using System.Threading.Tasks;
using Movies.Models;
using Movies.Services.Movies;
using Movies.ViewModels.Base;

namespace Movies.ViewModels
{
    public class MovieDetailsViewModel : BaseViewModel
    {
        private Movie _movie;
        private IMoviesService _moviesService;

        public MovieDetailsViewModel(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public Movie Movie
        {
            get { return _movie; }
            set
            {
                _movie = value;
                OnPropertyChanged(nameof(Movie));
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is Movie)
            {
                IsBusy = true;

                var movie = (Movie)navigationData;
                Movie = await _moviesService.FindByIdAsync(movie.Id, "en");


                IsBusy = false;
            }
        }
    }
}
