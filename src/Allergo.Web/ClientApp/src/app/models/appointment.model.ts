export class Appointment{
    constructor(
        public hour: number,
        public minutes: number,
        public isCurrentUser: boolean
    ) {}
}