using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Movies.Models;
using Movies.Services;
using Movies.ViewModels.Base;
using Xamarin.Forms;

namespace Movies.ViewModels
{
    public class MoviesListViewModel : BaseViewModel
    {
        private ObservableCollection<Movie> _movies;
        private INavigationService _navigationService;

        public MoviesListViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

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

        public override Task InitializeAsync(object navigationData)
        {
            IsBusy = true;


            List<Movie> list = new List<Movie>()
            {
                new Movie(){ Title = "Title 1", ReleaseDate = DateTime.Now, Overview="This is a test", Popularity=2,VoteAverage=2, VoteCount=1, PosterPath="https://es.web.img2.acsta.net/medias/nmedia/18/90/04/41/20078157.jpg"},
                new Movie(){ Title = "Title 2", ReleaseDate = DateTime.Now, Overview="This is a test", Popularity=2,VoteAverage=2, VoteCount=1, PosterPath="https://es.web.img2.acsta.net/medias/nmedia/18/90/04/41/20078157.jpg"},
                new Movie(){ Title = "Title 3", ReleaseDate = DateTime.Now, Overview="This is a test", Popularity=2,VoteAverage=2, VoteCount=1, PosterPath="https://es.web.img2.acsta.net/medias/nmedia/18/90/04/41/20078157.jpg"},
                new Movie(){ Title = "Title 4", ReleaseDate = DateTime.Now, Overview="This is a test", Popularity=2,VoteAverage=2, VoteCount=1, PosterPath="https://es.web.img2.acsta.net/medias/nmedia/18/90/04/41/20078157.jpg"},
            };

            Movies = new ObservableCollection<Movie>(list);

            IsBusy = false;

            return Task.FromResult(true);
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
