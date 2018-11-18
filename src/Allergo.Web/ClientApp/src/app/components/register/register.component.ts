import { Component } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

export class MyErrorStateMatcher implements ErrorStateMatcher {
    isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
        const isSubmitted = form && form.submitted;
        return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
    }
}

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
})
export class RegisterComponent {
    public email: string;
    public login: string;
    public password: string;
    public message: string;

    emailFormControl = new FormControl('', [
        Validators.required,
        Validators.email,
    ]);

    matcher = new MyErrorStateMatcher();

    constructor(private authService: AuthService) { }

    submit() {
        this.authService
            .register(this.email, this.login, this.password)
            .subscribe(result => {
                localStorage.setItem('token', result);
                this.message = "";
                //redirect
            }, error => this.message = "Email lub hasło są niepoprawne.");
    }
}
