using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace WpfApp1
{
    public class PhoneValidation : ValidationRule
    { 
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var re = new Regex(@"[1-9]{3}-[1-9]{3}-[1-9]{3}", RegexOptions.IgnoreCase);
            if (!re.IsMatch((string)value))
                return new ValidationResult(false, "Value is not correct phone number!");

            return ValidationResult.ValidResult;
        }
    }
}
