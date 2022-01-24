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
        private IMoviesManager _moviesManager;

        public MovieDetailsViewModel(IMoviesManager moviesManager)
        {
            _moviesManager = moviesManager;
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
                Movie = await _moviesManager.FindByIdAsync(movie.Id);


                IsBusy = false;
            }
        }
    }
}
