using System.Globalization;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace WpfApp1
{
    public class EmailValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var re = new Regex(@".{1,}@.{1,}\..{2,}", RegexOptions.IgnoreCase);
            if (!re.IsMatch((string)value))
                return new ValidationResult(false, "Value is not correct email address!");

            return ValidationResult.ValidResult;
        }
    }
}
