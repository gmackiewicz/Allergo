import { Component } from '@angular/core';
import { DoctorUtil } from '../../../utils/doctor.util';
import { ScheduleUtil } from '../../../utils/schedule.util';
import { Appointment } from '../../../models/appointment.model';
import { DatePipe } from '@angular/common';
import { AppointmentService } from '../../../services/appointment.service';
import { EditDiagnosisComponent } from './edit-diagnosis/edit-diagnosis.component';
import { MatDialog } from '@angular/material';

@Component({
    selector: 'app-set-diagnosis',
    templateUrl: './set-diagnosis.component.html'
})
export class SetDiagnosisComponent {
    appointments: Appointment[];
    pipe = new DatePipe('pl-PL');

    constructor(
        private scheduleUtil: ScheduleUtil,
        private doctorUtil: DoctorUtil,
        private appointmentService: AppointmentService,
        public dialog: MatDialog) { }

    ngOnInit(): void {
        this.getAppointments();
    }

    getAppointments(): any {
        this.appointmentService
            .getDoctorCompletedAppointments()
            .subscribe(result => {
                this.appointments = result;
            })
    }

    getAppointmentTitle(appointment: Appointment) {
        return this.pipe.transform(appointment.date, 'medium') + ', ' + this.doctorUtil.getFullName(appointment.user)
    }

    openDialog(appointment): void {
        const dialogRef =
            this.dialog
                .open(EditDiagnosisComponent, {
                    width: '450px',
                    data: appointment
                })
                .afterClosed()
                .subscribe((result) => {
                    if (result === "success") this.getAppointments();
                });
    }
}
