import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from './../../../models/user.model';
import { UsersService } from './../../../services/users.service';

@Component({
    selector: 'app-users',
    templateUrl: './users.component.html',
})
export class UsersComponent {
    users: User[];

    constructor(private userService: UsersService) {
        let usersTmp = this.userService.getUsers(10, 0);

        console.log(usersTmp);
    }

}