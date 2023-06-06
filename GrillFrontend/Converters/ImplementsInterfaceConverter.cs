using GrillBackend.Models.Abstractions;
using System;
using System.Globalization;
using System.Windows.Data;

namespace GrillFrontend.Converters
{
    public class ImplementsInterfaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IGrillable yourObject)
            {
                return yourObject is IGrillable;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
