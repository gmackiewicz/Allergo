using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Allergo.Account.Contracts;
using Allergo.Account.Models;
using Allergo.Data.Contracts;
using Allergo.Data.Models.Account;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Allergo.Account.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AllergoUser> _userManager;
        private readonly RoleManager<AllergoRole> _roleManager;
        private readonly IUserValidationService _userValidationService;
        private readonly IDataService _dataService;

        public UserService(
            UserManager<AllergoUser> userManager,
            IUserValidationService userValidationService,
            RoleManager<AllergoRole> roleManager,
            IDataService dataService)
        {
            _userManager = userManager;
            _userValidationService = userValidationService;
            _roleManager = roleManager;
            _dataService = dataService;
        }

        public async Task<List<UserDto>> GetUsersAsync(int take, int skip)
        {
            var users = await _userManager
                .Users
                .Skip(skip * take)
                .Take(take)
                .ToListAsync();

            var result = Mapper.Map<List<AllergoUser>, List<UserDto>>(users);

            foreach (var user in result)
            {
                var roleName = (await _userManager.GetRolesAsync(users.First(x => x.Id.ToString() == user.Id))).First();

                var role =
                    await _dataService
                        .GetSet<AllergoRole>()
                        .Where(x => x.Name == roleName)
                        .Select(x => new RoleDto
                        {
                            Id = x.Id.ToString(),
                            Name = x.Name
                        })
                        .FirstAsync();

                user.Role = role;
            }

            return result;
        }

        public async Task EditUserAsync(EditUserRequestDto requestDto)
        {
            _userValidationService.ValidateEditViewModel(requestDto);

            var user = await _userManager.FindByIdAsync(requestDto.Id);
            user.Email = requestDto.Email;
            user.UserName = requestDto.UserName;

            await _userManager.UpdateAsync(user);

            await SetRoleForUserAsync(user, requestDto.RoleId);
        }

        private async Task SetRoleForUserAsync(AllergoUser user, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (await _userManager.IsInRoleAsync(user, role.Name))
            {
                return;
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            await _userManager.AddToRoleAsync(user, role.Name);
        }

        public async Task<UserDto> GetUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var result = Mapper.Map<AllergoUser, UserDto>(user);

            var roleName = (await _userManager.GetRolesAsync(user)).First();

            var role =
                await _dataService
                    .GetSet<AllergoRole>()
                    .Where(x => x.Name == roleName)
                    .Select(x => new RoleDto
                    {
                        Id = x.Id.ToString(),
                        Name = x.Name
                    })
                    .FirstAsync();

            result.Role = role;

            return result;
        }

        public async Task<AllergoUser> GetUserByName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        public async Task<List<RoleDto>> GetRolesAsync()
        {
            var roles =
                await _dataService
                    .GetSet<AllergoRole>()
                    .Select(x => new RoleDto
                    {
                        Id = x.Id.ToString(),
                        Name = x.Name
                    })
                    .ToListAsync();

            return roles;
        }
    }
}
