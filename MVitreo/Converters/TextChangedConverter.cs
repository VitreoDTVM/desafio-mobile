using System;
using System.Globalization;
using Xamarin.Forms;

namespace MVitreo.Converters
{
    public class TextChangedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TextChangedEventArgs textChangedEventArgs))
                throw new ArgumentException("Expected value to be of type textChangedEventArgs", nameof(value));

            return textChangedEventArgs.NewTextValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
