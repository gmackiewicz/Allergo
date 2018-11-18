using Allergo.Account.Contracts;
using Allergo.Account.Models;
using Allergo.Common.Exceptions;

namespace Allergo.Account.Services
{
    public class UserValidationService : IUserValidationService
    {
        public void ValidateEditViewModel(EditUserViewModel model)
        {
            if (string.IsNullOrEmpty(model.Id))
            {
                throw new BadRequestException(
                    $"Edit user error: Id cannot be null!");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                throw new BadRequestException(
                    $"Edit user error: Email cannot be null!");
            }

            if (string.IsNullOrEmpty(model.UserName))
            {
                throw new BadRequestException(
                    $"Edit user error: UserName cannot be null!");
            }
        }
    }
}