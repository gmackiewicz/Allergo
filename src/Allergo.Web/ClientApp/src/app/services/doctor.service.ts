import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map'

import { Doctor } from '../models/doctor.model';
import { BaseService } from './base.service';

@Injectable()
export class DoctorService extends BaseService{

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        super(http, baseUrl);
    }
    
    getDoctors() {
        let url = this.baseUrl + 'api/Doctor/GetDoctors';

        return this.http.get<Doctor[]>(url);
    }
}