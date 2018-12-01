using System;

namespace Allergo.Web.ViewModels.Schedule
{
    public class GetScheduleRequestViewModel
    {
        public string DoctorId { get; set; }
        public DateTime DayFrom { get; set; }
    }
}
