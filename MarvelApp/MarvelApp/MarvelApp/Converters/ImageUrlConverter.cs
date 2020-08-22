using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace MarvelApp.Converters
{
    public class ImageUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                WebClient Client = new WebClient();
                string fullPath = ((string)value) + "/portrait_medium.jpg"; ;
                var byteArray = Client.DownloadData(fullPath);
                return ImageSource.FromStream(() => new MemoryStream(byteArray));
            }
            catch { return null; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
