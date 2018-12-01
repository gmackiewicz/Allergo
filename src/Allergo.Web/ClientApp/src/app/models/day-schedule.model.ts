import { Appointment } from "./appointment.model";

export class DaySchedule {
    constructor(
        public day: Date, 
        public appointments: Appointment[]
    ) { }
}