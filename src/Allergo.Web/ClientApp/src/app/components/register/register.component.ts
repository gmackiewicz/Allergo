import { Component } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { FormControl, FormGroupDirective, NgForm, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

export class MyErrorStateMatcher implements ErrorStateMatcher {
    isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
        const invalidCtrl = !!(control && control.invalid && control.parent.dirty);
        const invalidParent = !!(control && control.parent && control.parent.invalid && control.parent.dirty);
    
        return (invalidCtrl || invalidParent);
    }
}

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
})
export class RegisterComponent {
    registerForm: FormGroup;
    message: string;
    matcher = new MyErrorStateMatcher();

    
    constructor(private authService: AuthService, private formBuilder: FormBuilder) {
        this.registerForm = this.formBuilder.group({
            email: [
                '', 
                [ Validators.required, Validators.email ]
            ],
            login: [
                '', 
                [ Validators.required ]
            ],
            password: [
                '', 
                [ Validators.required ]
            ],
            confirmPassword: ['']
        }, { 
            validator: this.checkPasswords 
        });
    }
    
    submit() {
        this.authService
            .register(
                this.registerForm.controls.email.value, 
                this.registerForm.controls.login.value, 
                this.registerForm.controls.password.value)
            .subscribe(result => {
                localStorage.setItem('token', result);
                this.message = "";
                //redirect
            }, error => this.message = "Email lub hasło są niepoprawne.");
    }

    checkPasswords(group: FormGroup) {
        let password = group.controls.password.value;
        let confirmPassword = group.controls.confirmPassword.value;
    
        return password === confirmPassword ? null : { notSame: true }     
    }
}
