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
        private IMoviesManager _moviesManager;

        public MoviesListViewModel(INavigationService navigationService, IMoviesManager moviesManager)
        {
            _navigationService = navigationService;
            _moviesManager = moviesManager;

            SelectedMovieCommand = new Command(SelectedMovie);
            GetTopRatedCommand = new Command(async () => await GetTopRatedAsync(null));
            GetPopularCommand = new Command(GetPopularAsync);
            ChangeLanguageCommand = new Command(ChangeLanguage);
        }

        public Command SelectedMovieCommand { get; }

        public Command GetTopRatedCommand { get; }

        public Command GetPopularCommand { get; }

        public Command ChangeLanguageCommand { get; }

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
             await GetTopRatedAsync(navigationData);
        }

        private void SelectedMovie(object obj)
        {
            if (obj != null)
            {
                _navigationService.NavigateToAsync<MovieDetailsViewModel>(obj);
            }
        }

        private async void GetPopularAsync(object obj)
        {
            IsBusy = true;

            bool forceRequest = !AppResources.Culture.Name.Equals(AppSettings.USLanguage);

            await _moviesManager.DeleteAsync();

            var result = await _moviesManager.GetPopularAsync(AppSettings.Pages, AppResources.Culture.TwoLetterISOLanguageName, forceRequest);

            Movies = new ObservableCollection<Movie>(result);
            

            IsBusy = false;
        }

        private async Task GetTopRatedAsync(object obj)
        {
            IsBusy = true;

            bool forceRequest = !AppResources.Culture.Name.Equals(AppSettings.USLanguage);

            await _moviesManager.DeleteAsync();

            var result = await _moviesManager.GetTopRatedAsync(AppSettings.Pages, AppResources.Culture.TwoLetterISOLanguageName, forceRequest);

            Movies = new ObservableCollection<Movie>(result);
            

            IsBusy = false;
        }

        private void ChangeLanguage(object obj)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string action = await Application.Current.MainPage.DisplayActionSheet(AppResources.SelectLanguage, AppResources.Cancel, null, AppResources.Spanish, AppResources.English);

                if (action.Equals(AppResources.Spanish))
                {
                    SetLanguage(AppSettings.MXLanguage);
                }

                if (action.Equals(AppResources.English))
                {
                    SetLanguage(AppSettings.USLanguage);
                }

                await _navigationService.NavigateToAsync<MoviesListViewModel>();
            });
        }

        public void SetLanguage(string selectedLanguage)
        {
            AppResources.Culture = new System.Globalization.CultureInfo(selectedLanguage);

            AppProperties.SetProperty(AppSettings.SelectedLanguage, selectedLanguage);
        }
    }
}
