using System;
using System.Globalization;
using Xamarin.Forms;

namespace Movies.Converters
{
    public class MovieImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("{0}{1}", AppSettings.PosterImageUrl, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
