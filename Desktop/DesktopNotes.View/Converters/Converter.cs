using DesktopNotes.Model.Enums;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DesktopNotes.View.Converters
{
    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter.ToString() == "Date")
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
            else if (parameter.ToString() == "TaskNameValidation")
            {
                return string.IsNullOrWhiteSpace((value ?? "").ToString()) ? false : true;
            }
            else if(parameter.ToString() == "DateMain")
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
            else if(parameter.ToString() == "Color")
            {
                if (value != null)
                {
                    switch (value)
                    {
                        case StatusColor.Blue:
                            return Brushes.Blue;
                        case StatusColor.Green:
                            return Brushes.Green;
                        case StatusColor.Orange:
                            return Brushes.Orange;
                        default:
                            return Brushes.White;
                    }
                }
                else
                {
                    return Brushes.White;
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
