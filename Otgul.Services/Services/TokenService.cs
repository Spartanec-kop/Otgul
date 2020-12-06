using Microsoft.IdentityModel.Tokens;
using Otgul.Services.Interfaces;
using Otgul.Services.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Otgul.Services.Services
{
    public class TokenService : ITokenService
    {
        public string Generate(string userLogin)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userLogin)
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromDays(AuthOptions.Lifetime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }


        public ClaimsPrincipal DecodeToken(string jwt)
        {
            var validationParameters = AuthOptions.GetTokenParameters();

            try
            {
                var claimsPrincipal = new JwtSecurityTokenHandler()
                    .ValidateToken(jwt, validationParameters, out var _);

                return claimsPrincipal;
            }
            catch (SecurityTokenValidationException stvex)
            {
                // The token failed validation!
                return null;
            }
            catch (ArgumentException argex)
            {
                // The token was not well-formed or was invalid for some other reason.
                return null;
            }
        }
    }
}
