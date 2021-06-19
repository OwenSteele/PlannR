using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlannR.App.Infrastructure.Validation
{
    public class PasswordAttribute : ValidationAttribute
    {

        public const string DefaultErrorMessage = "Password must contain : lower and upper case letters, a number, with a minimum length of 8.";
        public PasswordAttribute() : base(DefaultErrorMessage) { }

        public override bool IsValid(object value)
        {
            if (value.GetType() != typeof(string)) throw new InvalidCastException("Passwords must be of type string");

            StringBuilder sb = new("Invalid password: ");
            var isValid = true;

            var password = (string)value;

            if (!Regex.IsMatch(password, "[a-z]"))
            {
                sb.Append("must contain lowercase letter(s), ");
                isValid = false;
            }
            if (!Regex.IsMatch(password, "[A-Z]"))
            { 
                sb.Append("must contain uppercase letter(s), ");
                isValid = false;
            }

            if (!Regex.IsMatch(password, "[0-9]"))
            {
                sb.Append("must contain a number, ");
                isValid = false;
            }
            if (password.Length < 8)
            {
                sb.Append("must be at least 8 characters ");
                isValid = false;
            }

            ErrorMessage = sb.ToString();

            return isValid;
        }
    }
}
