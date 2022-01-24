using System;
using Xamarin.Forms;

namespace Movies
{
    public static class AppProperties
    {
        public static string GetProperty(string name)
        {
            if (Application.Current.Properties.ContainsKey(name))
            {
                return (string)Application.Current.Properties[name];
            }

            return null;
        }

        public async static void SetProperty(string name, string value)
        {
            if (Application.Current.Properties.ContainsKey(name))
            {
                Application.Current.Properties[name] = value;
            }
            else
            {
                Application.Current.Properties.Add(name, value);
            }

            await Application.Current.SavePropertiesAsync();
        }
    }
}
