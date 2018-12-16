import Rolemodel = require("./role.model");
import Role = Rolemodel.Role;

export class User {
    constructor(
        public id: string, 
        public userName: string, 
        public email: string,
        public firstName: string,
        public lastname: string,
        public role: Role) { }
}
