import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './../../../models/user.model';
import { UsersService } from './../../../services/users.service';

@Component({
    selector: 'app-users',
    templateUrl: './users.component.html',
})
export class UsersComponent {
    users: User[];

    constructor(private userService: UsersService, 
                private router: Router) {
        this.userService
            .getUsers(10, 0)
            .subscribe(response => this.users = response);
    }


    userSelected(id) {
        this.router.navigateByUrl('admin/user/' + id);
    }
}