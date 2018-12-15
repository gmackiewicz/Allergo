import { Component, OnInit } from '@angular/core';
import { ScheduleService } from '../../../services/schedule.service';
import { AdmissionHours } from '../../../models/admission-hours.model';
import { ScheduleUtil } from '../../../utils/schedule.util';

@Component({
    selector: 'app-schedule',
    templateUrl: './schedule.component.html',
})

export class ScheduleComponent implements OnInit {
    schedule: AdmissionHours;

    constructor(
        private scheduleService: ScheduleService,
        private scheduleUtil: ScheduleUtil) { }

    ngOnInit() {
        this.getAdmissionHours();
    }

    getAdmissionHours = () => {
        this.scheduleService
            .getAdmissionHours()
            .subscribe(response => {
                this.schedule = response;
                console.log(response);
            });
    }
}