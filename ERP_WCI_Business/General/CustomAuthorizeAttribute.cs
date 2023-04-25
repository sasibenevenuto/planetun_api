using ERP_WCI_Business.General.Interfaces;
using ERP_WCI_Model.General;
using ERP_WCI_Model.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ERP_WCI_Business.General
{
    public class CustomAuthorizeAttribute : ICustomAuthorizeAttribute
    {
        private Settings _settings;
        private TokenConfigurations _tokenConfigurations;
        public CustomAuthorizeAttribute(IOptions<Settings> settings)
        {
            _settings = settings.Value;
            _tokenConfigurations = new TokenConfigurations();
        }

        public async Task<string> Authenticate(string xSignature, User user)
        {
            if (xSignature == _settings.Secret)
            {
                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                ClaimsIdentity identity = new ClaimsIdentity(
                   new GenericIdentity(user.UserName, "Login"),
                   new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("State", "Get"),
                        new Claim("City", "Get"),
                        new Claim("Inspection", "Get"),
                        new Claim("Inspection", "Post")
                   }
               );

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_settings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return await Task.Run(() => tokenHandler.WriteToken(token));
            }
            else
            {
                return null;
            }
        }

        public string CreateToken(string secret)
        {
            var encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(_settings.PublicMessage);
            using (var hmacsha512 = new HMACSHA512(messageBytes))
            {
                byte[] hashmessage = hmacsha512.ComputeHash(keyByte);
                return Convert.ToBase64String(hashmessage);
            }
        }

        public string CreateHashTokenIntranet(string secret, string password)
        {
            var encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(password);
            using (var hmacsha512 = new HMACSHA512(messageBytes))
            {
                byte[] hashmessage = hmacsha512.ComputeHash(keyByte);
                return Convert.ToBase64String(hashmessage);
            }
        }

        public void OnAuthorization(AuthorizationFilterContext authorizationFilterContext)
        {
            if (authorizationFilterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (!authorizationFilterContext.HttpContext.User.HasClaim(x => x.Value == "CLAIM_NAME"))
                {
                    authorizationFilterContext.Result = new ObjectResult(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}
