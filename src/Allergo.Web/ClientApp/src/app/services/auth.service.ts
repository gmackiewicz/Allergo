import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginModel } from './../models/login.model';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthService {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    
    login(login, password): Observable<boolean> {
        let loginModel = new LoginModel(login, password);
        let url = this.baseUrl + 'api/Auth/Login';

        console.log(loginModel);
        console.log(url);

        return this.http
            .post<string>(url, loginModel)
            .map(result => {
                    localStorage.setItem('token', result);
                    return true;
                }, 
                error => {
                    console.error(error)
                    return false;
                });

    }
}