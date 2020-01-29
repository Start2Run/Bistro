using System;

namespace SystemePAC.Help.Convertors
{
    public class ImageFromByteArrayConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is byte[] byteArray)) return null;
            return Common.ImageHelper.ImageFromByteArray(byteArray);
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
