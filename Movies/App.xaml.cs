using System;
using System.Threading.Tasks;
using Movies.Services.Navigation;
using Movies.ViewModels.Base;
using Movies.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movies
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitNavigation();
        }

        private Task InitNavigation()
        {
            var navigationService = Locator.Instance.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
