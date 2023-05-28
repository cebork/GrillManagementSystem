using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using GrillBackend.Models.Enums;

namespace GrillFrontend.Converters
{
    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case Status.preparing: return "W trakcie przygotowania"; break;
                case Status.in_progress: return "W trakcie"; break;
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
