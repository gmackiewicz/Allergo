using System;

namespace Allergo.Common.Exceptions
{
    public class SignInFailedException : BadRequestException
    {
        public SignInFailedException()
        {
        }

        public SignInFailedException(string message) : base(message)
        {
        }

        public SignInFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
