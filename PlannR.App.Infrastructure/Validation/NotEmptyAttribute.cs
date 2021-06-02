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

            return value switch
            {
                Guid guid => guid != Guid.Empty,
                DateTime date => date != DateTime.MinValue,
                int i => i != 0,
                string str => !string.IsNullOrWhiteSpace(str),
                _ => true,
            };
        }
    }
}
