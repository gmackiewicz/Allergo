import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import 'rxjs/add/operator/map'

import { User } from './../../../models/user.model';
import { EditUserRequest } from '../models/requests/edit-user-request.model';

@Injectable()
export class UsersService {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    
    getUsers(take, skip) {
        let url = this.baseUrl + 'api/Auth/Login';

        let params = new HttpParams()
            .set("take", take)
            .set("skip", skip);

        return this.http.get(url, { params: params}).map(
            response => <User>response
        );
    }

    updateUser(id, email, userName) {
        let registerModel = new EditUserRequest(id, email, userName);
        let url = this.baseUrl + 'api/Auth/Register';

        return this.http.post(url, registerModel);
    }
}