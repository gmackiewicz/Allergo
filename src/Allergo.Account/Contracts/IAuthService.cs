using Allergo.Account.Models;
using System.Threading.Tasks;

namespace Allergo.Account.Contracts
{
    public interface IAuthService
    {
        Task<string> Register(RegisterViewModel model);
        Task<string> SignIn(SignInViewModel model);
    }
}
