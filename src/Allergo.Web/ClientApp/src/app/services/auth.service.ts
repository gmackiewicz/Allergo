import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginModel } from './../models/login.model';

@Injectable()
export class AuthService {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    
    login(login, password) {
        let loginModel = new LoginModel(login, password);
        let url = this.baseUrl + 'api/Auth/Login';

        console.log(loginModel);
        console.log(url);

        this.http
            .post<string>(url, loginModel)
            .subscribe(result => {
                    localStorage.setItem('token', result);
                }, 
                error => console.error(error));
    }
}