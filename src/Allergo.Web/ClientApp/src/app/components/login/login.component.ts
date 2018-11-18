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

    constructor(private authService: AuthService) { }

    submit() {
        this.authService
            .login(this.login, this.password)
            .subscribe(result => {
                localStorage.setItem('token', result);
                this.message = "";
                //redirect
            }, error => this.message = "Email lub hasło są niepoprawne.");
    }
}
