﻿using Byway.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Services
{
    public class AuthService(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task<string> CreateTokenAsync(ApplicationUser user, UserManager<ApplicationUser> userManager)
        {
            // Private Claims
            var privateClaims = new List<Claim>()
            {
                new(ClaimTypes.Name, user.FullName),
                new(ClaimTypes.Email, user.Email),
            };

            var userRoles = await userManager.GetRolesAsync(user);
            if (userRoles.Any())
            {
                foreach (var role in userRoles)
                    privateClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            // set Security Key
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:AuthKey"] ?? string.Empty));

            // Generate JWT token
            var token = new JwtSecurityToken
                (
                    // Registered Claims
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:DurationInDays"] ?? "0")),
                    // private claims
                    claims: privateClaims,
                    // security Algorithem 
                    signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
