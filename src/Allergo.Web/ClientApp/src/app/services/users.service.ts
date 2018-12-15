import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map'

import { User } from './../models/user.model';
import { EditUserRequest } from '../models/requests/edit-user-request.model';
import Rolemodel = require("../models/role.model");
import Role = Rolemodel.Role;

@Injectable()
export class UsersService {
    private http: HttpClient;
    private baseUrl: string;
    private headers: HttpHeaders;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.headers = new HttpHeaders({
            'Authorization': 'Bearer ' + localStorage.getItem('token')
        });
    }

    getUsers(take, skip) {
        let url = this.baseUrl + 'api/User/GetUsers';

        let params = new HttpParams()
            .set("take", take)
            .set("skip", skip);

        return this.http.get<User[]>(url, { params: params, headers: this.headers });
    }

    getUser(id) {
        let url = this.baseUrl + 'api/User/GetUser';

        let params = new HttpParams()
            .set("id", id);

        return this.http.get<User>(url, { params: params, headers: this.headers });
    }

    getRoles() {
        let url = this.baseUrl + 'api/User/GetRoles';

        return this.http.get<Role[]>(url, { headers: this.headers });
    }

    updateUser(id, email, userName, roleId) {
        let registerModel = new EditUserRequest(id, email, userName, roleId);
        let url = this.baseUrl + 'api/User/Edit';

        return this.http.put<User>(url, registerModel, { headers: this.headers });
    }
}