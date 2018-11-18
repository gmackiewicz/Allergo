using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Allergo.Account.Contracts;
using Allergo.Account.Models;
using Allergo.Data.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Allergo.Account.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AllergoUser> _userManager;
        private readonly IUserValidationService _userValidationService;

        public UserService(UserManager<AllergoUser> userManager, IUserValidationService userValidationService)
        {
            _userManager = userManager;
            _userValidationService = userValidationService;
        }

        public async Task<List<AllergoUser>> GetAll(int take, int skip)
        {
            return await _userManager.Users.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<AllergoUser> EditUser(EditUserViewModel userViewModel)
        {
            _userValidationService.ValidateEditViewModel(userViewModel);

            var user = await _userManager.FindByIdAsync(userViewModel.Id);
            user.Email = userViewModel.Email;
            user.UserName = userViewModel.UserName;
            await _userManager.UpdateAsync(user);

            return user;
        }
    }
}