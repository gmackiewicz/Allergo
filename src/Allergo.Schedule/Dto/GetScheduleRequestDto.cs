using System;

namespace Allergo.Schedule.Dto
{
    public class GetScheduleRequestDto
    {
        public string DoctorId { get; set; }
        public DateTime DayFrom { get; set; }
    }
}
