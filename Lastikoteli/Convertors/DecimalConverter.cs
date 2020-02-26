using System;
using System.Globalization;
using Xamarin.Forms;

namespace Lastikoteli.Convertors
{
    public class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal)
                return value.ToString();
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal dec;
            value=value.ToString().Replace(".", ",");
            if (decimal.TryParse(value as string, out dec))
                return dec;
            return value;
        }
    }
}
