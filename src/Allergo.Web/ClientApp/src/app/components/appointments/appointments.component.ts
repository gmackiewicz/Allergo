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
import { Appointment } from '../../models/appointment.model';
import { SetAppointmentComponent } from './set-appointment/set-appointment.component';
import { RemoveAppointmentComponent } from './remove-appointment/remove-appointment.component';
import { DaySchedule } from '../../models/day-schedule.model';

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
        this.doctorService
            .getDoctors()
            .subscribe(response => {
                this.doctors = response;
                this.filteredDoctors = 
                    this.doctorsControl.valueChanges
                        .pipe(
                            map(val => val ? this.filterDoctors(val) : this.doctors.slice())
                        );
            })
    }

    filterDoctors(val): Doctor[] {
        if (typeof val === 'string') {
            return this.doctors
                .filter(doctor => {
                    return this.doctorUtil.getFullName(doctor).toLowerCase().includes(val.toLowerCase());
                }); 
        } 
    }

    doctorSelected = (doctor) => {
        this.doctorsControl.setValue(this.doctorUtil.getFullName(doctor));
        this.selectedDoctor = doctor;
        this.getSchedule(doctor.Id);
    }

    getSchedule = (doctorId) => {
        this.scheduleService
            .getSchedule(doctorId, Date.now())
            .subscribe(response => {
                this.schedule = response;
                this.schedule.daySchedules.forEach(ds => {
                    ds.appointments.forEach(a => a.taken = true);
                });
                this.schedule.daySchedules.forEach(ds => {
                    for (var h = 7; h < 19; h++) {
                        for (var m = 0; m < 60; m += 15) {
                            if (ds.appointments.filter(a => a.hour === h && a.minutes === m).length === 0) {
                                ds.appointments.push(new Appointment(h, m, false, false));
                            }
                        }
                    }

                    ds.appointments.sort(a => a.minutes).sort(a => a.hour);
                })
            });
    }

    appointmentClick = (appointment, day) => {
        this.openDialog(appointment, day);
    }

    openDialog(appointment: Appointment, day: DaySchedule) {
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