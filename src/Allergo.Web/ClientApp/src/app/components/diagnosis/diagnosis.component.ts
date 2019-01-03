import { Component } from '@angular/core';
import { DoctorUtil } from '../../utils/doctor.util';
import { ScheduleUtil } from '../../utils/schedule.util';
import { Appointment } from '../../models/appointment.model';
import { DatePipe } from '@angular/common';
import { AppointmentService } from '../../services/appointment.service';

@Component({
    selector: 'app-diagnosis',
    templateUrl: './diagnosis.component.html'
})
export class DiagnosisComponent {
    appointments: Appointment[];
    pipe = new DatePipe('pl-PL');

    constructor(
        private scheduleUtil: ScheduleUtil,
        private doctorUtil: DoctorUtil,
        private appointmentService: AppointmentService) { }

    ngOnInit(): void {
        this.getAppointments();
    }

    getAppointments(): any {
        this.appointmentService
            .getUserAppointments()
            .subscribe(result => {
                this.appointments = result;
                console.log(this.appointments);
            })
    }

    getAppointmentTitle(appointment: Appointment) {
        return this.pipe.transform(appointment.date, 'medium') + ' u ' + this.doctorUtil.getFullName(appointment.doctor)
    }
}