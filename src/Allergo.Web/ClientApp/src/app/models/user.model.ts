export class User {
    constructor(
        public id: string, 
        public userName: string, 
        public normalizedUserName: string, 
        public email: string, 
        public normalizedEmail: string, 
        public emailConfirmed: boolean, 
        public passwordHash: string, 
        public securityStamp: string, 
        public concurrencyStamp: string, 
        public phoneNumber: string, 
        public phoneNumberConfirmed: boolean, 
        public twoFactorEnabled: boolean, 
        public lockoutEnd: string, 
        public lockoutEnabled: boolean, 
        public accessFailedCount: number) { }
}