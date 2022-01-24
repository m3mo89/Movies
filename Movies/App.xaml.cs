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

        public static void RegisterType<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            Locator.Instance.RegisterType<TInterface, T>();
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
