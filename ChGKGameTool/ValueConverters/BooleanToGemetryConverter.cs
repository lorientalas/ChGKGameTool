using System;
using System.Globalization;
using System.Windows.Media;

namespace ChGKGameTool
{
    /// <summary>
    /// A converter that takes in a boolean and returns a thickness of 2 if true, useful for applying 
    /// border radius on a true value
    /// </summary>
    public class BooleanToGemetryConverter : BaseValueConverter<BooleanToGemetryConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ?
                                Geometry.Parse("M19,13H13V19H11V13H5V11H11V5H13V11H19V13Z") :
                                Geometry.Parse("M19,13H5V11H19V13Z");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
