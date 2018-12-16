import { Time } from "@angular/common";

export class AdmissionHours {
    constructor(
        public id: string,
        public day: Date,
        public startTime: Time,
        public endTime: Time
    ) { }
}