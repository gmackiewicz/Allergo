import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map'

import { JwtUtil } from '../utils/jwt.util';

import { LoginRequest } from '../models/requests/login-request.model';
import { RegisterRequest } from '../models/requests/register-request.model';

@Injectable()
export class AuthService {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private jwtUtil: JwtUtil) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    
    login(login, password) {
        let loginModel = new LoginRequest(login, password);
        let url = this.baseUrl + 'api/Auth/Login';

        return this.http.post<string>(url, loginModel);
    }

    register(email, login, password) {
        let registerModel = new RegisterRequest(email, login, password);
        let url = this.baseUrl + 'api/Auth/Register';

        return this.http.post<string>(url, registerModel);
    }

    isLoggedIn() {
        const token = localStorage.getItem('token');

        if (token != null){
            const decodedToken = this.jwtUtil.decode(localStorage.getItem('token'));
            const currentUnixTimestamp = Math.round((new Date()).getTime() / 1000);
        
            if (decodedToken.exp > currentUnixTimestamp){
                return true;
            }
        }
        return false;
    }
}