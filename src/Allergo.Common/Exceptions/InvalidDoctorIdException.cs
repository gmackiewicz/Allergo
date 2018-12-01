using System;

namespace Allergo.Common.Exceptions
{
    public class InvalidDoctorIdException : BadRequestException
    {
        public InvalidDoctorIdException()
        {
        }

        public InvalidDoctorIdException(string message) : base(message)
        {
        }

        public InvalidDoctorIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
