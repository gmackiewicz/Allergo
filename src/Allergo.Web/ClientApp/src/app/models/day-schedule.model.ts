import { ScheduleTerm } from "./schedule-term.model";

export class DaySchedule {
    constructor(
        public day: Date, 
        public terms: ScheduleTerm[]
    ) { }
}
