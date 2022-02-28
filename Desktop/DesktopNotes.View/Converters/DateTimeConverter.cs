using System;
using System.Globalization;
using System.Windows.Data;

namespace DesktopNotes.View.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter.ToString() == "Date")
            {
                if (value != null)
                {
                    DateTime date = (DateTime)value;
                    string buffer = $"{date.Day}.{date.Month}.{date.Year}";
                    return buffer;
                }
                else
                {
                    return "";
                }
            }
            else if (parameter.ToString() == "DateMain")
            {
                if (value != null)
                {
                    DateTime date = (DateTime)value;
                    string buffer = String.Format("Current date: {0:dd.MM.yyyy}", date);
                    return buffer;
                }
                else
                {
                    return "Current date: ";
                }
            }
            else if (parameter.ToString() == "DateUC")
            {
                if (value != null)
                {
                    DateTime date = (DateTime)value;
                    string buffer = String.Format("{0:dd.MM.yyyy}", date);
                    return buffer;
                }
                else
                {
                    return "Current date: ";
                }
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
