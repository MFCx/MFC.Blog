﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.Business.StringInfos;
using MFC.Blog.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;


namespace MFC.Blog.Business.Tools.JWTTools
{
    public class JwtManager:IJwtService
    {
        public JwtToken GenerateJwt(AppUser appUser)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer:JwtInfo.Issuer,audience:JwtInfo.Audience,claims:SetClaims(appUser),
                notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(JwtInfo.Expires),
                signingCredentials:signingCredentials 
                
                );

            JwtToken jwtToken = new JwtToken();
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            jwtToken.Token=handler.WriteToken(jwtSecurityToken);
            return jwtToken;
        }

        private List<Claim> SetClaims(AppUser appUser)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name,appUser.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,appUser.Id.ToString()));

            return claims;
        }
    }
}
