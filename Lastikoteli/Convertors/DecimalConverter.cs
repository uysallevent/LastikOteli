using System;
using System.Globalization;
using Xamarin.Forms;

namespace Lastikoteli.Convertors
{
    public class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            decimal thedecimal = (decimal)value;
            return thedecimal.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            string strValue = value as string;
            if (string.IsNullOrEmpty(strValue))
                strValue = "0";

            strValue = strValue.Replace(".", ",");
            decimal resultdecimal;
            if (decimal.TryParse(strValue, out resultdecimal))
            {
                return resultdecimal;
            }
            return 0;
        }
    }
}
