using System;
using Movies.Services.Navigation;
using Unity;

namespace Movies.ViewModels.Base
{
    public class Locator
    {
        private readonly IUnityContainer _container;

        private static readonly Locator _instance = new Locator();

        public static Locator Instance
        {
            get
            {
                return _instance;
            }
        }

        protected Locator()
        {
            _container = new UnityContainer();
            _container.RegisterType<INavigationService, NavigationService>();

            _container.RegisterType<MoviesListViewModel>();
            _container.RegisterType<MovieDetailsViewModel>();
        }

        public void RegisterType<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.RegisterType<TInterface, T>();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
