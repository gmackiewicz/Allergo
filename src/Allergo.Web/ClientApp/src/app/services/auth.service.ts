import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginRequest } from '../models/login-request.model';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthService {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    
    login(login, password) {
        let loginModel = new LoginRequest(login, password);
        let url = this.baseUrl + 'api/Auth/Login';

        return this.http.post<string>(url, loginModel);
    }
}