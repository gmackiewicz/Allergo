namespace Allergo.Web.ViewModels.Schedule
{
    public class DayScheduleTermViewModel
    {
        public int Hour { get; set; }
        public int Minutes { get; set; }
        public bool IsTaken { get; set; }
        public bool IsTakenByCurrentUser { get; set; }
        public string AppointmentId { get; set; }
    }
}