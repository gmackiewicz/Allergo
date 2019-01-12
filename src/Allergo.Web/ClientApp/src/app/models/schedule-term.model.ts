export class ScheduleTerm {
    constructor(
        public hour: number,
        public minutes: number,
        public isTaken: boolean,
        public isTakenByCurrentUser: boolean,
        public appointmentId: string) {
    }
}
