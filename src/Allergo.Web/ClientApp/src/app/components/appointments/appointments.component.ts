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
import { map } from 'rxjs/operators';
import { ScheduleAppointment } from '../../models/schedule-appointment.model';
import { SetAppointmentComponent } from './set-appointment/set-appointment.component';
import { RemoveAppointmentComponent } from './remove-appointment/remove-appointment.component';
import { DaySchedule } from '../../models/day-schedule.model';

import * as moment from 'moment';

@Component({
    selector: 'app-appointments',
    templateUrl: './appointments.component.html'
})
export class AppointmentsComponent {
    doctorsControl = new FormControl();
    schedule: Schedule;
    doctors: Doctor[];
    filteredDoctors: Observable<Doctor[]>;
    selectedDoctor: Doctor;

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
                        .map(val => val ? this.filterDoctors(val) : response.slice());
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
                this.schedule = this.groupByDay(response);
                this.schedule.daySchedules.forEach(ds => {
                    ds.appointments.forEach(a => a.taken = false);
                    ds.appointments.sort(function(a, b) {return a.minutes - b.minutes}).sort(function(a, b) {return a.hour - b.hour});
                });
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
                existingDaySchedule.appointments = existingDaySchedule.appointments.concat(d.appointments);
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

    openDialog(appointment: ScheduleAppointment, day: DaySchedule) {
        if (appointment.isCurrentUser) {
            const dialogRef = 
                this.dialog
                    .open(RemoveAppointmentComponent, {
                            height: 'auto',
                            width: '400px',
                            data: { 
                                doctor: this.selectedDoctor, 
                                appointment: appointment
                            }
                        })
                    .afterClosed()
                    .subscribe(result => this.getSchedule(this.selectedDoctor.id));
        } else {
            const dialogRef = 
                this.dialog
                    .open(SetAppointmentComponent, {
                            height: 'auto',
                            width: '400px',
                            data: { 
                                doctor: this.selectedDoctor, 
                                appointment: appointment,
                                day: day.day
                            }
                        })
                    .afterClosed()
                    .subscribe(result => this.getSchedule(this.selectedDoctor.id));
        }
    }
}
