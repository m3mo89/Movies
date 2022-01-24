using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.ViewModels;
using Xamarin.Forms;

namespace Movies.Views
{
    public partial class MoviesListPage : ContentPage
    {
        public MoviesListPage()
        {
            var vm = new MoviesListViewModel();
            Task.Run(async () => await vm.InitializeAsync(null));
            BindingContext = vm;
            InitializeComponent();
        }
    }
}
