using System;
using Localization;

namespace Movies.CommandImplementation.Receivers
{
    public class SpanishLanguageReceiver : ILanguageReceiver
    {
        public void SetLanguage()
        {
            AppResources.Culture = new System.Globalization.CultureInfo(AppSettings.MXLanguage);

            AppProperties.SetProperty(AppSettings.SelectedLanguage, AppSettings.MXLanguage);
        }
    }
}

