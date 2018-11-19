export class EditUserRequest {
    constructor(
        public Id: number,
        public Email: string, 
        public UserName: string) { }
}