import { Component, Inject } from '@angular/core';
import { AuthService } from './../../services/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
})
export class LoginComponent {
    public login: string;
    public password: string;

    constructor(private authService: AuthService) { }

    submit() {
        this.authService.login(this.login, this.password);
    }
}
