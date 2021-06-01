using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PlannR.Application.Contracts.Identity;
using PlannR.Application.Models.Authentication;
using PlannR.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PlannR.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<PlannrUser> _userManager;
        private readonly SignInManager<PlannrUser> _signInManager;
        private readonly JwtSettings _jwtOptions;

        public AuthenticationService(UserManager<PlannrUser> userManager,
            SignInManager<PlannrUser> signInManager,
            IOptions<JwtSettings> jwtOptions)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            var existingUsername = await _userManager.FindByNameAsync(request.UserName);
            if (existingUsername != null) throw new Exception($"This Username ('{request.UserName}') is aready taken.");

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingEmail != null) throw new Exception($"This Email ('{request.Email}') already belongs to an account.");

            var newUser = new PlannrUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded) throw new Exception($"{result.Errors}");

            return new RegistrationResponse() { UserId = newUser.Id };


        }
        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var existing = await _userManager.FindByEmailAsync(request.Email);
            if (existing == null) throw new Exception($"User with email '{request.Email}', was not found.");

            var result = await _signInManager.PasswordSignInAsync(
                existing.UserName,
                request.Password,
                true,
                false);

            if (!result.Succeeded) throw new Exception($"Invalid details for '{request.Email}");

            var expiry = DateTime.Now.AddMinutes(_jwtOptions.DurationInMinutes);

            var token = await GenerateJwtTokenAsync(existing, expiry);

            return new AuthenticationResponse
            {
                UserName = existing.UserName,
                UserId = existing.Id,
                Email = existing.Email,
                Token = token,
                TokenExpiry = expiry
            };
        }

        private async Task<string> GenerateJwtTokenAsync(PlannrUser user, DateTime expiry)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            var tokenClaims = new List<Claim>
            {
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                };
            foreach (var role in userRoles) tokenClaims.Add(new Claim("roles", role));
            foreach (var claim in userClaims) tokenClaims.Add(claim);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                tokenClaims,
                expires: expiry,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
