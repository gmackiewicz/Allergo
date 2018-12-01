import { Appointment } from "./appointment.model";

export class DaySchedule {
    constructor(
        public Day: Date, 
        public appointments: Appointment
    ) { }
}