import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from './../../../models/user.model';
import { UsersService } from './../../../services/users.service';
import { Role } from './../../../models/role.model';
import { JwtUtil } from '../../../utils/jwt.util'

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
    roles: Role[];
    selectedRoleId: string;

    constructor(private userService: UsersService,
        private route: ActivatedRoute,
        private formBuilder: FormBuilder,
        private router: Router,
        private jwtUtil: JwtUtil) {
        this.editUserForm = this.formBuilder.group({
            email: [
                '',
                [Validators.required]
            ],
            userName: [
                '',
                [Validators.required]
            ],
            role: [
                '',
                [Validators.required]
            ]
        });
    }

    ngOnInit(): void {
        this.sub = this.route.params.subscribe(params => {
            this.id = params['id'];

            this.userService
                .getRoles()
                .subscribe(res => {
                    this.roles = res;
                });

            this.userService
                .getUser(this.id)
                .subscribe(result => {
                    this.editUserForm.controls.email.setValue(result.email);
                    this.editUserForm.controls.userName.setValue(result.userName);
                    this.editUserForm.controls.role.setValue(result.role.id);
                });
        });
    }

    backToList() {
        this.router.navigateByUrl('/admin/users');
    }

    submit() {
        var currentUserId = this.jwtUtil.decode(localStorage.getItem('token')).jti;
        var currentUserRoleName = this.jwtUtil.decode(localStorage.getItem('token')).role;
        console.log(currentUserId);
        console.log(currentUserRoleName);
        if (this.id === currentUserId && this.editUserForm.controls.role.value !== this.roles.find(x => x.name === currentUserRoleName).id)
        {
            this.message = "Nie możesz pozbawić się roli administratora."
        } else
        {
            this.userService
                .updateUser(
                    this.id,
                    this.editUserForm.controls.email.value,
                    this.editUserForm.controls.userName.value,
                    this.editUserForm.controls.role.value)
                .subscribe(result => {
                    },
                    error => this.message = "Wystąpił błąd. Przepraszamy :(");
        }
    }
    getPolishRoleName(roleName) {
        roleName = roleName.toLowerCase();
        if (roleName === "admin") {
            return "Administrator";
        } else if (roleName == "doctor") {
            return "Doktor";
        } else {
            return "Pacjent";
        }
    }
}
