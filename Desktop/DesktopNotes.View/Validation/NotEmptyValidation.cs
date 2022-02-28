using System.Globalization;
using System.Windows.Controls;

namespace DesktopNotes.View.Validation
{
    public class NotEmptyValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Null value")
                : ValidationResult.ValidResult;
        }
    }
}
