using System;
using Localization;

namespace Movies.CommandImplementation.Receivers
{
    public class EnglishLanguageReceiver : ILanguageReceiver
    {
        public void SetLanguage()
        {
            AppResources.Culture = new System.Globalization.CultureInfo(AppSettings.USLanguage);

            AppProperties.SetProperty(AppSettings.SelectedLanguage, AppSettings.USLanguage);
        }
    }
}
