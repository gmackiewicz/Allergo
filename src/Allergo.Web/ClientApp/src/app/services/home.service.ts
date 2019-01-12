import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map'

import { BaseService } from './base.service';
import { DashboardData } from '../models/dashboard-data.model';

@Injectable()
export class HomeService extends BaseService {

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        super(http, baseUrl);
    }

    getDashboardData() {
        let url = this.baseUrl + 'Home/GetDashboardData';

        let params = new HttpParams();

        return this.http.get<DashboardData>(url, { headers: this.headers });
    }
}
