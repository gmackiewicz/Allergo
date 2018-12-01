import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map'

import { SetAppointmentRequest } from '../models/requests/set-appointment-request.model';
import { CancelAppointmentRequest } from '../models/requests/cancel-appointment-request.model';

@Injectable()
export class AppointmentService {
    private http: HttpClient;
    private baseUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    
    setAppointment(date, userId, doctorId) {
        let url = this.baseUrl + 'api/Appointment/SetAppointment';
        let body = new SetAppointmentRequest(date, userId, doctorId);

        return this.http.post(url, body);
    }
    
    cancelAppointment(appointmentId) {
        let url = this.baseUrl + 'api/Appointment/CancelAppointment';
        let body = new CancelAppointmentRequest(appointmentId);

        return this.http.post(url, body);
    }
}