using System;
using System.ComponentModel.DataAnnotations;

namespace PlannR.App.Infrastructure.Validation
{
    public class NotEmptyAttribute : ValidationAttribute
    {

        public const string DefaultErrorMessage = "This field cannot be empty";
        public NotEmptyAttribute() : base(DefaultErrorMessage) { }

        public override bool IsValid(object value)
        {
            if (value is null) return true;

            switch (value)
            {
                case Guid guid:
                    return guid != Guid.Empty;
                case DateTime date:
                    return date != DateTime.MinValue;
                case int i:
                    return i != 0;
                case string str:
                    return !string.IsNullOrWhiteSpace(str);   
                default:
                    return true;
            }
        }
    }
}
