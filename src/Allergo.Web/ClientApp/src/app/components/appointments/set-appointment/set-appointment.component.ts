import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { Appointment } from "../../../models/appointment.model";
import { Doctor } from "../../../models/doctor.model";
import { ScheduleUtil } from "../../../utils/schedule.util";
import { DoctorUtil } from "../../../utils/doctor.util";
import { AppointmentService } from "../../../services/appointment.service";

@Component({
    selector: 'app-set-appointment',
    templateUrl: './set-appointment.component.html',
})
export class SetAppointmentComponent {
    constructor(
        public dialogRef: MatDialogRef<SetAppointmentComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private scheduleUtil: ScheduleUtil,
        private doctorUtil: DoctorUtil,
        private appointmentService: AppointmentService) {}

    submit = () => {
        let newDate = new Date(this.data.day);
        newDate.setUTCHours(this.data.appointment.hour);
        newDate.setUTCMinutes(this.data.appointment.minutes);

        this.appointmentService
            .setAppointment(newDate, '', this.data.doctor.id)
            .subscribe(result => this.dialogRef.close())
    }
}