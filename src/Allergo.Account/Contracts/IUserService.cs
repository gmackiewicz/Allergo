using System.Collections.Generic;
using System.Threading.Tasks;
using Allergo.Account.Models;
using Allergo.Data.Models.Account;

namespace Allergo.Account.Contracts
{
    public interface IUserService
    {
        Task<AllergoUser> EditUser(EditUserViewModel userViewModel);
        Task<List<AllergoUser>> GetAll(int take, int skip);
        Task<AllergoUser> GetUser(string id);
        Task<AllergoUser> GetUserByName(string userName);
    }
}