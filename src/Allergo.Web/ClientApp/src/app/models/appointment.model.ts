export class Appointment{
    constructor(
        public id: string,
        public hour: number,
        public minutes: number,
        public isCurrentUser: boolean,
        public taken: boolean = true
    ) {}
}