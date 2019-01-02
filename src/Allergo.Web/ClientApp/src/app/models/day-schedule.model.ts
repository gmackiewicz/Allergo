import { ScheduleAppointment } from "./schedule-appointment.model";

export class DaySchedule {
    constructor(
        public day: Date, 
        public appointments: ScheduleAppointment[]
    ) { }
}