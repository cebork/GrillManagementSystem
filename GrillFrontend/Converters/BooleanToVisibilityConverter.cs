using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using GrillBackend.Models.GrillStuff;
using System.Diagnostics.Metrics;

namespace GrillFrontend.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GrillMember grillMember=(GrillMember)value;
            return MainWindow.grillLogic.CurrentGrill.GrillMembers.Contains(grillMember) ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
