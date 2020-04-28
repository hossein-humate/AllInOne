using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.DTO.General;
using Model.Entity.Identity;
using static System.String;

namespace AllInOne.Infrastructure.Service
{
    public interface IJwtAuthenticationService
    {
        string CreateTokenAuthentication(User user);

        string CheckTokenValidate(string token);
    }

    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly Token _tokenModel;

        public JwtAuthenticationService(IOptions<Token> tokenModel)
        {
            _tokenModel = tokenModel.Value;
        }

        public string CreateTokenAuthentication(User user)
        {
            try
            {
                IEnumerable<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, "Customer")
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenModel.Secret));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var jwtToken = new JwtSecurityToken(
                    _tokenModel.Issuer,
                    _tokenModel.Audience,
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(_tokenModel.AccessExpiration),
                    signingCredentials: credentials
                );
                return new JwtSecurityTokenHandler().WriteToken(jwtToken);
            }
            catch (Exception)
            {
                return Empty;
            }
        }

        public string CheckTokenValidate(string token)
        {
            try
            {
                var param = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenModel.Secret)),
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidIssuer = _tokenModel.Issuer,
                    ValidAudience = _tokenModel.Audience,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(token, param, out _);
                var validTo = handler.ReadToken(token).ValidTo;
                if (DateTime.UtcNow <= validTo) return token;
                return Empty;
            }
            catch (Exception)
            {
                return Empty;
            }
        }
    }
}