using Allergo.Web.ViewModels.Common;
using System.Collections.Generic;

namespace Allergo.Web.ViewModels.Schedule
{
    public class ScheduleViewModel
    {
        public DoctorViewModel Doctor { get; set; }
        public List<DayScheduleViewModel> DaySchedules { get; set; }
    }
}
