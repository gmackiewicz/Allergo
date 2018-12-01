import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import 'rxjs/add/operator/map'

import { Schedule } from './../models/schedule.model';
import { ScheduleRequest } from '../models/requests/schedule-request.model';

@Injectable()
export class ScheduleService {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    
    getSchedule(doctorId, dayFrom) {
        let url = this.baseUrl + 'api/Schedule/GetSchedule';
        let registerModel = new ScheduleRequest(doctorId, dayFrom);

        return this.http.post<Schedule>(url, registerModel);
    }
}