using System;
using System.Runtime.Serialization;

namespace Allergo.Common.Exceptions
{
    public class InvalidAppointmentIdException : Exception
    {
        public InvalidAppointmentIdException()
        {
        }

        public InvalidAppointmentIdException(string message) : base(message)
        {
        }

        public InvalidAppointmentIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAppointmentIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
