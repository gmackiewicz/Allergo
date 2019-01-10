import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { ScheduleUtil } from "../../../../utils/schedule.util";
import { ScheduleService } from "../../../../services/schedule.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { AppointmentService } from "../../../../services/appointment.service";
import { DoctorUtil } from "../../../../utils/doctor.util";
import { DatePipe } from "@angular/common";

@Component({
    selector: 'app-edit-diagnosis-hour',
    templateUrl: './edit-diagnosis.component.html',
})
export class EditDiagnosisComponent {
    editDiagnosisForm: FormGroup;
    diagnosis: string;
    pipe = new DatePipe('pl-PL');

    constructor(
        public dialogRef: MatDialogRef<EditDiagnosisComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private doctorUtil: DoctorUtil,
        private appointmentService: AppointmentService,
        private formBuilder: FormBuilder) 
    {
        this.editDiagnosisForm = this.formBuilder.group({
            diagnosis: [
                this.data.diagnosis,
                [Validators.required]
            ],
        });
    }

    submit = () => {
        this.appointmentService
            .setAppointmentDiagnosis(
                this.data.id,
                this.editDiagnosisForm.controls.diagnosis.value)
            .subscribe(result => this.dialogRef.close());
    }
}