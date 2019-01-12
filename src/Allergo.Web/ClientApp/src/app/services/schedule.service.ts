import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import 'rxjs/add/operator/map'

import { Schedule } from './../models/schedule.model';
import { ScheduleRequest } from '../models/requests/schedule-request.model';
import { AdmissionHours } from '../models/admission-hours.model';
import { BaseService } from './base.service';
import { NewAdmissionHourRequest } from '../models/requests/new-admission-hour-request.model';

@Injectable()
export class ScheduleService extends BaseService {

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        super(http, baseUrl);
    }

    getSchedule(doctorId, dayFrom) {
        let url = this.baseUrl + 'Schedule/GetSchedule';
        let getScheduleModel = new ScheduleRequest(doctorId, dayFrom);

        return this.http.post<Schedule>(url, getScheduleModel, { headers: this.headers });
    }

    getAdmissionHours() {
        let url = this.baseUrl + 'Schedule/GetAdmissionHours';

        return this.http.get<AdmissionHours[]>(url, { headers: this.headers });
    }

    createAdmissionHour(weekDay, startTime, endTime) {
        let url = this.baseUrl + 'Schedule/CreateSchedule';
        let request = new NewAdmissionHourRequest(weekDay, startTime, endTime);

        return this.http.post(url, request, { headers: this.headers });
    }

    removeAdmissionHours(admissionId) {
        let url = this.baseUrl + 'Schedule/RemoveSchedule';

        let params = new HttpParams()
            .set("scheduleId", admissionId);

        return this.http.delete(url, { params: params, headers: this.headers });
    }
}
