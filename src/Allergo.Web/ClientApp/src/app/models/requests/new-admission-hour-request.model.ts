import { Time } from "@angular/common";

export class NewAdmissionHourRequest {
    constructor(
        public DayOfWeek: number,
        public StartTime: Time,
        public EndTime: Time) { }
}