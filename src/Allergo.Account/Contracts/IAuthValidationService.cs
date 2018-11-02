using Allergo.Account.Models;

namespace Allergo.Account.Contracts
{
    public interface IAuthValidationService
    {
        void ValidateRegisterViewModel(RegisterViewModel model);
        void ValidateSignInViewModel(SignInViewModel model);
    }
}
