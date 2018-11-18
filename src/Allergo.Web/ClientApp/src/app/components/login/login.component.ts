import { Component } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
})
export class LoginComponent {
    loginForm: FormGroup;
    public login: string;
    public password: string;
    public message: string;

    constructor(private authService: AuthService, private formBuilder: FormBuilder) {
        this.loginForm = this.formBuilder.group({
            login: [
                '', 
                [ Validators.required ]
            ],
            password: [
                '', 
                [ Validators.required ]
            ]
        });
    }

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
