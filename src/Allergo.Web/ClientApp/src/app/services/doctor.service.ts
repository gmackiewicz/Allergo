import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map'

import { Doctor } from '../models/doctor.model';

@Injectable()
export class DoctorService {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    
    getDoctors() {
        let url = this.baseUrl + 'api/Doctor/GetDoctors';

        return this.http.get<Doctor[]>(url);
    }
}