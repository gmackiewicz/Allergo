import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { Appointment } from "../../../models/appointment.model";
import { Doctor } from "../../../models/doctor.model";
import { ScheduleUtil } from "../../../utils/schedule.util";
import { DoctorUtil } from "../../../utils/doctor.util";
import { AppointmentService } from "../../../services/appointment.service";

@Component({
    selector: 'app-remove-appointment',
    templateUrl: './remove-appointment.component.html',
})
export class RemoveAppointmentComponent {
    constructor(
        public dialogRef: MatDialogRef<RemoveAppointmentComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private scheduleUtil: ScheduleUtil,
        private doctorUtil: DoctorUtil,
        private appointmentService: AppointmentService) {}

    submit = () => {
        this.appointmentService
            .cancelAppointment(this.data.appointment.id)
            .subscribe(result => this.dialogRef.close());
    }
}