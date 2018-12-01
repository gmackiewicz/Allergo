using Allergo.Account.Contracts;
using Allergo.Account.Models;
using Allergo.Common.Exceptions;

namespace Allergo.Account.Services
{
    public class AuthValidationService : IAuthValidationService
    {
        public void ValidateRegisterViewModel(RegisterViewModel model)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(model.Email);
            }
            catch
            {
                throw new RegistrationFailedException(
                    $"Invalid email!");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                throw new RegistrationFailedException(
                    $"Registration error: Password cannot be null!");
            }

            if (string.IsNullOrEmpty(model.UserName))
            {
                throw new RegistrationFailedException(
                    $"Registration error: UserName cannot be null!");
            }
        }

        public void ValidateSignInViewModel(SignInViewModel model)
        {
            if (string.IsNullOrEmpty(model.Password))
            {
                throw new SignInFailedException(
                    $"Password cannot be empty nor null!");
            }

            if (string.IsNullOrEmpty(model.UserName))
            {
                throw new SignInFailedException(
                    $"UserName cannot be empty nor null!");
            }
        }
    }
}
