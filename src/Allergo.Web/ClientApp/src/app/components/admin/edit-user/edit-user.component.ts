import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from './../../../models/user.model';
import { UsersService } from './../../../services/users.service';

@Component({
    selector: 'app-edit-user',
    templateUrl: './edit-user.component.html',
})
export class EditUserComponent implements OnInit {
    editUserForm: FormGroup;
    message: string;
    id: string;
    private sub: any;
    users: User;

    constructor(private userService: UsersService, 
                private route: ActivatedRoute, 
                private formBuilder: FormBuilder, 
                private router: Router) {
        this.editUserForm = this.formBuilder.group({
            email: [
                '', 
                [ Validators.required ]
            ],
            userName: [
                '', 
                [ Validators.required ]
            ]
        });
    }

    ngOnInit(): void {
        this.sub = this.route.params.subscribe(params => {
            this.id = params['id'];
     
            this.userService
                .getUser(this.id)
                .subscribe(result => {
                    this.editUserForm.controls.email.setValue(result.email);
                    this.editUserForm.controls.userName.setValue(result.userName);
                });
         });
    }

    backToList() {
        this.router.navigateByUrl('/admin/users');
    }

    submit() {
        this.userService
            .updateUser(this.id, this.editUserForm.controls.email.value, this.editUserForm.controls.userName.value)
            .subscribe(result => {
                console.log(result);
            }, error => this.message = "Wystąpił błąd. Przepraszamy :(");
    }
}