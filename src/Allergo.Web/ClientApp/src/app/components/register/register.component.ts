import { Component } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { FormControl, FormGroupDirective, NgForm, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Router } from '@angular/router';

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
    isLinear = true;
    externalAuthForm: FormGroup;
    registerForm: FormGroup;
    message: string;
    matcher = new MyErrorStateMatcher();

    
    constructor(private authService: AuthService, private formBuilder: FormBuilder, private router: Router) {
        this.externalAuthForm = this.formBuilder.group({
            login: [
                '', 
                [ Validators.required ]
            ],
            password: [
                '', 
                [ Validators.required ]
            ]
        });

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
    
    stepperChange(stepper) {
        if (stepper.selectedIndex === 1) {
            
        }
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
                this.router.navigateByUrl('');
            }, error => {
                console.log(error);
                this.message = "Wystąpił błąd, przepraszamy :("
            });
    }

    checkPasswords(group: FormGroup) {
        let password = group.controls.password.value;
        let confirmPassword = group.controls.confirmPassword.value;
    
        return password === confirmPassword ? null : { notSame: true }     
    }
}
