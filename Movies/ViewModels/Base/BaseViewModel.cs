using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Movies.ViewModels.Base
{
    public class BaseViewModel : BindableObject
    {
        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
