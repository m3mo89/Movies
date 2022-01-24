using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Localization;
using Movies.Models;
using Movies.Services.Movies;
using Movies.Services.Navigation;
using Movies.ViewModels.Base;
using Xamarin.Forms;

namespace Movies.ViewModels
{
    public class MoviesListViewModel : BaseViewModel
    {
        private ObservableCollection<Movie> _movies;
        private INavigationService _navigationService;
        private IMoviesService _moviesService;

        public MoviesListViewModel(INavigationService navigationService, IMoviesService moviesService)
        {
            _navigationService = navigationService;
            _moviesService = moviesService;

            SelectedMovieCommand = new Command(SelectedMovie);
        }

        public Command SelectedMovieCommand { get; }

        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set
            {
                _movies = value;
                OnPropertyChanged(nameof(Movies));
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            var result = await _moviesService.GetTopRatedAsync(1, "en");

            Movies = new ObservableCollection<Movie>(result.Results);

            IsBusy = false;
        }

        private void SelectedMovie(object obj)
        {
            if (obj != null)
            {
                _navigationService.NavigateToAsync<MovieDetailsViewModel>(obj);
            }
        }
    }
}
