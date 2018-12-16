import { Component, OnInit } from '@angular/core';
import { ScheduleService } from '../../../services/schedule.service';
import { AdmissionHours } from '../../../models/admission-hours.model';
import { ScheduleUtil } from '../../../utils/schedule.util';
import { AddAdmissionHourComponent } from './add-admission-hour/add-addmission-hour.component';
import { MatDialog } from '@angular/material';

@Component({
    selector: 'app-schedule',
    templateUrl: './schedule.component.html',
})

export class ScheduleComponent implements OnInit {
    schedule: AdmissionHours;

    constructor(
        private scheduleService: ScheduleService,
        private scheduleUtil: ScheduleUtil,
        public dialog: MatDialog) { }

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

    showNewAdmissionHoursDialog = () => {
        this.openDialog();
    }

    openDialog(): void {
        const dialogRef =
            this.dialog
                .open(AddAdmissionHourComponent, {
                    width: '450px'
                })
                .afterClosed()
                .subscribe(result =>
                    console.log(result)
                );
    }
}