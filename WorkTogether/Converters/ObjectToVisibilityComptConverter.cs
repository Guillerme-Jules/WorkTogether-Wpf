using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WorkTogether.DBlib.Class;

namespace WorkTogether.Wpf.Converters
{
    class ObjectToVisibilityComptConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = Visibility.Collapsed;
            if (((User)value).Roles.Contains(parameter as string))
            {
                visibility = Visibility.Visible;
            }
            else
            {
                visibility = Visibility.Collapsed;
            }
            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
