using System;
using Localization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Movies.Extensions
{
    [ContentProperty(nameof(ResourceName))]
    public class LocalizedExtension : IMarkupExtension
    {
        public string ResourceName { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var currentCulture = AppResources.Culture;

            return AppResources.ResourceManager.GetString(ResourceName, currentCulture);
        }
    }
}
