import { Component } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { JwtUtil } from '../../utils/jwt.util';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
})
export class LoginComponent {
    public login: string;
    public password: string;
    public message: string;

    constructor(private authService: AuthService, private jwtUtil: JwtUtil) { }

    submit() {
        
        if (this.authService.login(this.login, this.password)) {
            console.log(this.jwtUtil.decode(localStorage.getItem('token')));
            //redirect
        } else {
            this.message = "Email lub hasło są niepoprawne."
        }
    }
}
