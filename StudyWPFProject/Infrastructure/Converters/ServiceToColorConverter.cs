using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace StudyWPFProject.Infrastructure.Converters
{
    public class ServiceToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value.ToString();
            if (status != null)
            {
                if (status.Equals("Discord")) return Brushes.DarkGray;
                if (status.Equals("Zoom")) return Brushes.AliceBlue;
                if (status.Equals("WebinarSFU")) return Brushes.Orange;
            }
            
            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Need implementation if need convert color to text");
        }
    }
}
