import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
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
        let tmpDate = new Date(this.data.day);
        let newDate = new Date();
        newDate.setUTCFullYear(tmpDate.getFullYear());
        newDate.setUTCMonth(tmpDate.getMonth());
        newDate.setUTCDate(tmpDate.getDate());
        newDate.setUTCHours(this.data.term.hour);
        newDate.setUTCMinutes(this.data.term.minutes);
        newDate.setUTCSeconds(0);

        this.appointmentService
            .setAppointment(newDate, this.data.doctor.id)
            .subscribe(result => this.dialogRef.close())
    }
}
