using System;

namespace PlannR.Application.Models.Authentication
{
    public class AuthenticationResponse
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiry { get; set; }
    }
}
