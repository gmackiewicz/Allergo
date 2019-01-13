import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog, AUTOCOMPLETE_OPTION_HEIGHT } from '@angular/material';

import { Schedule } from '../../models/schedule.model';
import { Doctor } from '../../models/doctor.model';

import { ScheduleService } from './../../services/schedule.service';
import { DoctorService } from '../../services/doctor.service';
import { ScheduleUtil } from '../../utils/schedule.util';
import { DoctorUtil } from '../../utils/doctor.util';

import { Observable } from 'rxjs/Observable';
import { SetAppointmentComponent } from './set-appointment/set-appointment.component';
import { RemoveAppointmentComponent } from './remove-appointment/remove-appointment.component';
import { DaySchedule } from '../../models/day-schedule.model';
import { ScheduleTerm } from '../../models/schedule-term.model';

import { startWith, map } from 'rxjs/operators';

import * as moment from 'moment';

@Component({
    selector: 'app-appointments',
    templateUrl: './appointments.component.html',
    styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent {
    doctorsControl = new FormControl();
    schedule: Schedule;
    doctors: Doctor[];
    filteredDoctors: Observable<Doctor[]>;
    selectedDoctor: Doctor;
    errorMessage: string = "";

    constructor(
        private scheduleService: ScheduleService,
        private doctorService: DoctorService,
        private scheduleUtil: ScheduleUtil,
        private doctorUtil: DoctorUtil,
        private dialog: MatDialog) { }

    ngOnInit(): void {
        this.doctorsControl.setValue('');

        this.doctorService
            .getDoctors()
            .subscribe(response => {
                this.doctors = response;
                this.filteredDoctors =
                    this.doctorsControl
                    .valueChanges
                    .pipe(startWith(''), map(val => val ? this.filterDoctors(val) : response.slice()));
            });
    }

    filterDoctors(val): Doctor[] {
        if (typeof val === 'string') {
            return this.doctors
                .filter(doctor => {
                    return this.doctorUtil.getFullName(doctor).toLowerCase().includes(val.toLowerCase());
                }); 
        } 

        return this.doctors.slice();
    }

    doctorSelected = (doctor) => {
        this.doctorsControl.setValue(this.doctorUtil.getFullName(doctor));
        this.selectedDoctor = doctor;
        this.getSchedule(doctor.id);
    }

    getSchedule = (doctorId) => {
        this.scheduleService
            .getSchedule(doctorId, moment().format("YYYY-MM-DD"))
            .subscribe(response => {
                if (!response.daySchedules || response.daySchedules.length === 0) {
                    this.errorMessage = "Wybrany lekarz nie ma jeszcze wprowadzonego grafiku. Spróbuj wybrać innego!"
                } else {
                    this.schedule = this.groupByDay(response);
                    this.schedule.daySchedules.forEach(ds => {
                        ds.terms.sort(function (a, b) { return a.minutes - b.minutes }).sort(function (a, b) { return a.hour - b.hour });
                    });
                    this.errorMessage = "";
                }
            });
    }

    groupByDay = (source: Schedule) => {
        let result = new Schedule(source.doctor, null);
        source.daySchedules.forEach(d => 
        {
            let existingDaySchedule = 
                result.daySchedules !== null 
                    ? result.daySchedules.find(x => x.day === d.day) 
                    : undefined;
                    
            if (existingDaySchedule) {
                existingDaySchedule.terms = existingDaySchedule.terms.concat(d.terms);
            } else {
                if (!result.daySchedules) {
                    result.daySchedules = new Array<DaySchedule>();
                }
                result.daySchedules.push(d);
            }
        })

        return result;
    }

    appointmentClick = (appointment, day) => {
        this.openDialog(appointment, day);
    }

    openDialog(term: ScheduleTerm, day: DaySchedule) {
        if (term.isTakenByCurrentUser) {
            const dialogRef = 
                this.dialog
                    .open(RemoveAppointmentComponent, {
                            height: 'auto',
                            width: '400px',
                            data: { 
                                doctor: this.selectedDoctor, 
                                term: term
                            }
                        })
                    .afterClosed()
                    .subscribe(result => {
                        if (result === "success") this.getSchedule(this.selectedDoctor.id);
                    });
        } else if (!term.isTaken) {
            const dialogRef = 
                this.dialog
                    .open(SetAppointmentComponent, {
                            height: 'auto',
                            width: '400px',
                            data: { 
                                doctor: this.selectedDoctor, 
                                term: term,
                                day: day.day
                            }
                        })
                    .afterClosed()
                    .subscribe(result => {
                        if (result === "success") this.getSchedule(this.selectedDoctor.id);
                    });
        }
    }
}
