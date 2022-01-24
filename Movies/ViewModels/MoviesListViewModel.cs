using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Movies.Models;
using Movies.ViewModels.Base;

namespace Movies.ViewModels
{
    public class MoviesListViewModel : BaseViewModel
    {
        private ObservableCollection<Movie> _movies;

        public MoviesListViewModel()
        {
        }

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
                new Movie(){ Title = "title 1"},
                new Movie(){ Title = "title 1"},
                new Movie(){ Title = "title 1"},
                new Movie(){ Title = "title 1"},
            };

            Movies = new ObservableCollection<Movie>(list);

            IsBusy = false;

            return Task.FromResult(true);
        }
    }
}
