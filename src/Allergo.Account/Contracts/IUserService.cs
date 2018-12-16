using System.Collections.Generic;
using System.Threading.Tasks;
using Allergo.Account.Models;
using Allergo.Data.Models.Account;

namespace Allergo.Account.Contracts
{
    public interface IUserService
    {
        Task EditUserAsync(EditUserRequestDto requestDto);
        Task<List<UserDto>> GetUsersAsync(int take, int skip);
        Task<UserDto> GetUserAsync(string id);
        Task<AllergoUser> GetUserByName(string userName);
        Task<List<RoleDto>> GetRolesAsync();
    }
}
