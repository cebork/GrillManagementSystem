using GrillBackend.Models.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace GrillFrontend.Converters
{
    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Status.preparing: return "W trakcie przygotowania"; break;
                case Status.Ended: return "Zakończono"; break;
                default: return "idk";
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
