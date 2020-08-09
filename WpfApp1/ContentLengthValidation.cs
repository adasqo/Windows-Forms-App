using System.Globalization;
using System.Windows.Controls;

namespace WpfApp1
{
    public class ContentLengthValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Value cannot be empty.");
            if (value.ToString().Length < 5)
                return new ValidationResult(false, "Value must have at least 5 characters!");

            return ValidationResult.ValidResult;
        }
    }
}
