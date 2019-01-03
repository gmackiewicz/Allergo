import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map'

import { SetAppointmentRequest } from '../models/requests/set-appointment-request.model';
import { CancelAppointmentRequest } from '../models/requests/cancel-appointment-request.model';
import { BaseService } from './base.service';
import { Appointment } from '../models/appointment.model';

@Injectable()
export class AppointmentService extends BaseService {
    
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        super(http, baseUrl);
    }
    
    setAppointment(date, doctorId) {
        let url = this.baseUrl + 'Appointment/SetAppointment';
        let body = new SetAppointmentRequest(date, doctorId);

        return this.http.post(url, body, { headers: this.headers });
    }
    
    cancelAppointment(appointmentId) {
        let url = this.baseUrl + 'Appointment/CancelAppointment';
        let body = new CancelAppointmentRequest(appointmentId);

        return this.http.post(url, body, { headers: this.headers });
    }

    getUserAppointments() {
        let url = this.baseUrl + 'Appointment/GetUserAppointments';

        return this.http.get<Appointment[]>(url, { headers: this.headers });
    }
}