namespace Allergo.Schedule.Dto
{
    public class DayScheduleTermDto
    {
        public int Hour { get; set; }
        public int Minutes { get; set; }
        public bool IsTaken { get; set; }
        public bool IsTakenByCurrentUser { get; set; }
        public string AppointmentId { get; set; }
    }
}
