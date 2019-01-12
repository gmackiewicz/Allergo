using System;
using System.Runtime.Serialization;

namespace Allergo.Common.Exceptions
{
    public class CollidingAppointmentException : Exception
    {
        public CollidingAppointmentException()
        {
        }

        public CollidingAppointmentException(string message) : base(message)
        {
        }

        public CollidingAppointmentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CollidingAppointmentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
