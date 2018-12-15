using Allergo.Account.Models;

namespace Allergo.Account.Contracts
{
    public interface IUserValidationService
    {
        void ValidateEditViewModel(EditUserRequestDto model);
    }
}
