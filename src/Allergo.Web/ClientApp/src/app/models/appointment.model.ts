import { User } from "./user.model";

export class Appointment {
    constructor(
        public id: string,
        public date: Date,
        public user: User,
        public doctor: User,
        public isCancelled: boolean,
        public diagnosis: string,
        public isPast: boolean
    ) { }
}
