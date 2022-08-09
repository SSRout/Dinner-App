
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DinnerInvite.Application.Common.Interfaces.Authentication;
using DinnerInvite.Application.Common.Interfaces.Services;
using DinnerInvite.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DinnerInvite.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IjwtTokenGenearator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,IOptions<JwtSettings> jwtOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtOptions.Value;
        }

        public string GenToken(User user)
        {

            var signKey = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.secret)
            ),
            SecurityAlgorithms.HmacSha256
            );

            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.Sub,user.id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,user.LastName)
           };

           var securityToken=new JwtSecurityToken(
            issuer:_jwtSettings.issuer,
            audience:_jwtSettings.auddiance,
            expires:_dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.expMinutes),
            claims:claims,
            signingCredentials:signKey
           );

           return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}