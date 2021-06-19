using PlannR.App.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PLannR.App.Infrastructure.Tests.ValidationUnitTests
{
    public class PasswordAttributeTests
    {
        [InlineData("pwd", new string[] { "must contain uppercase letter(s)", "must contain a number", "must be at least 8 characters" })]
        [InlineData("passw0rd", new string[] { "must contain uppercase letter(s)" })]
        [InlineData("PASSW0RD", new string[] { "must contain lowercase letter(s)", })]
        [InlineData("PwD", new string[] { "must contain a number", "must be at least 8 characters", })]
        [InlineData("Passw0rd", new string[] { })]
        [Theory]
        public void WHEN_Invalid_Password_Is_Set_THEN_invalid_returned_with_specific_message(string password, string[] errorMessages)
        {
            var attribute = new PasswordAttribute();

            var result = attribute.IsValid(password);

            Assert.Equal(errorMessages.Length == 0, result);

            foreach(var error in errorMessages)
            {
                Assert.Contains(error, attribute.ErrorMessage);
            }
        }
    }
}
