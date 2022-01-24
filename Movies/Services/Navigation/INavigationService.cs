using System;
using System.Threading.Tasks;
using Movies.ViewModels.Base;

namespace Movies.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;
    }
}
