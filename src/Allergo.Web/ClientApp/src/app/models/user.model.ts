import { Role } from "./role.model";

export class User {
    constructor(
        public id: string, 
        public userName: string, 
        public email: string,
        public firstName: string,
        public lastname: string,
        public role: Role) { }
}
