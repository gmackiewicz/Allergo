using System;

namespace Allergo.Common.Exceptions
{
    public class RegistrationFailedException : BadRequestException
    {
        public RegistrationFailedException()
        {
        }

        public RegistrationFailedException(string message) : base(message)
        {
        }

        public RegistrationFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
