﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Allergo.Account.Contracts;
using Allergo.Account.Models;
using Allergo.Common.Enums;
using Allergo.Common.Exceptions;
using Allergo.Data.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Allergo.Account.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AllergoUser> _userManager;
        private readonly SignInManager<AllergoUser> _signInManager;
        private readonly IAuthValidationService _authValidationService;
        private readonly IConfiguration _configuration;

        public AuthService(
            UserManager<AllergoUser> userManager,
            SignInManager<AllergoUser> signInManager,
            IAuthValidationService authValidationService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authValidationService = authValidationService;
            _configuration = configuration;
        }

        public async Task<string> Register(RegisterViewModel model)
        {
            _authValidationService.ValidateRegisterViewModel(model);

            var newUser = new AllergoUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);
            await _userManager.AddToRoleAsync(newUser, AllergoRoleNames.Patient);

            if (!result.Succeeded)
            {
                throw new BadRequestException(
                    $"An error occured while registering user: {result.Errors.Select(x => x.Description).Join()}");
            }

            await _signInManager.SignInAsync(newUser, false);
            return await GetToken(newUser);
        }

        public async Task<string> SignIn(SignInViewModel model)
        {
            _authValidationService.ValidateSignInViewModel(model);

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (!result.Succeeded)
            {
                throw new BadRequestException(
                    $"An error occured while signing in user: {model.UserName}");
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            return await GetToken(user);
        }

        private async Task<string> GetToken(AllergoUser user)
        {
            var utcNow = DateTime.UtcNow;
            
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString(CultureInfo.InvariantCulture))
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
            {
                claims.Add(new Claim("role", role));
            }

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Tokens:Key")));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: utcNow,
                expires: utcNow.AddSeconds(_configuration.GetValue<int>("Tokens:Lifetime"))
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
