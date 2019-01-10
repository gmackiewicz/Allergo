export class ScheduleAppointment{
    constructor(
        public id: string,
        public hour: number,
        public minutes: number,
        public isCurrentUser: boolean,
        public taken: boolean = true,
        public diagnosis: string
    ) {}
}