using System;

namespace Allergo.Common.Exceptions
{
    public class CollidingScheduleException : BadRequestException
    {
        public CollidingScheduleException()
        {
        }

        public CollidingScheduleException(string message) : base(message)
        {
        }

        public CollidingScheduleException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
