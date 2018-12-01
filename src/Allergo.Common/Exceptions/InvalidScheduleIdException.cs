using System;

namespace Allergo.Common.Exceptions
{
    public class InvalidScheduleIdException : BadRequestException
    {
        public InvalidScheduleIdException()
        {
        }

        public InvalidScheduleIdException(string message) : base(message)
        {
        }

        public InvalidScheduleIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
