using GrillBackend.Models.Enums;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

public class ButtonVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Status status = (Status)value;
        return status != Status.Ended ? Visibility.Visible : Visibility.Hidden;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
