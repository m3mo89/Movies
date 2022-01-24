using System;
using System.Threading.Tasks;
using Movies.Models;
using Movies.ViewModels.Base;

namespace Movies.ViewModels
{
    public class MovieDetailsViewModel : BaseViewModel
    {
        private Movie _movie;

        public MovieDetailsViewModel()
        {
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

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData is Movie)
            {
                IsBusy = true;

                var movie = (Movie)navigationData;
                Movie = movie;

                IsBusy = false;
            }

            return Task.FromResult(true);
        }
    }
}
