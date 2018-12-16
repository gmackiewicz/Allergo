import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { ScheduleUtil } from "../../../../utils/schedule.util";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { ScheduleService } from "../../../../services/schedule.service";

@Component({
    selector: 'add-addmission-hour',
    templateUrl: './add-addmission-hour.component.html',
})
export class AddAdmissionHourComponent {
    addAdmissionHourForm: FormGroup;

    constructor(
        public dialogRef: MatDialogRef<AddAdmissionHourComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private scheduleUtil: ScheduleUtil,
        private formBuilder: FormBuilder,
        private scheduleService: ScheduleService) {
        this.addAdmissionHourForm = this.formBuilder.group({
            weekday: [
                '',
                [Validators.required]
            ],
            startTime: [
                '',
                [Validators.required]
            ],
            endTime: [
                '',
                [Validators.required]
            ]
        });
    }

    submit = () => {
        this.scheduleService
            .createAdmissionHour(
                this.addAdmissionHourForm.controls.weekday.value,
                this.addAdmissionHourForm.controls.startTime.value,
                this.addAdmissionHourForm.controls.endTime.value
            )
            .subscribe(() => this.dialogRef.close());
    }

    cancel(): void {
        this.dialogRef.close();
    }
}