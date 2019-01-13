import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { ScheduleUtil } from "../../../../utils/schedule.util";
import { ScheduleService } from "../../../../services/schedule.service";

@Component({
    selector: 'app-remove-admission-hour',
    templateUrl: './remove-admission-hour.component.html',
})
export class RemoveAdmissionHourComponent {
    constructor(
        public dialogRef: MatDialogRef<RemoveAdmissionHourComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private scheduleUtil: ScheduleUtil,
        private sheduleService: ScheduleService) {}

        ngOnInit(): void {
            //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
            //Add 'implements OnInit' to the class.
            console.log(this.data);
        }

    submit = () => {
        this.sheduleService
            .removeAdmissionHours(this.data.id)
            .subscribe(result => this.dialogRef.close("success"));
    }
}
