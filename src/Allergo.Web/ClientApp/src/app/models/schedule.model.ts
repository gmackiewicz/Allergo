import { Doctor } from "./doctor.model";
import { DaySchedule } from "./day-schedule.model";

export class Schedule {
    constructor(
        public doctor: Doctor, 
        public daySchedules: DaySchedule[]
    ) { }
}