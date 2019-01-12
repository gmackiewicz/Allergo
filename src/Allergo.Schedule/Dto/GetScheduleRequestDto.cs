using System;
using Allergo.Data.Models.Account;

namespace Allergo.Schedule.Dto
{
    public class GetScheduleRequestDto
    {
        public string DoctorId { get; set; }
        public DateTime DayFrom { get; set; }
        public AllergoUser CurrentUser { get; set; }
    }
}
