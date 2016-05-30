using System;
using Xamarin.Forms;

namespace OpenGLGuide.Converters
{
    public class BoolToArrowTypeConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var incomeValue = (bool)value;

            if (incomeValue)
                return "-";
            else
                return "+"; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

