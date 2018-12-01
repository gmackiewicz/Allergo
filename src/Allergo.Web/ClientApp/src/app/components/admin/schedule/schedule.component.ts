import { Component } from '@angular/core';
import { ScheduleService } from './../../../services/schedule.service';
import { Schedule } from '../../../models/schedule.model';

@Component({
    selector: 'app-schedule',
    templateUrl: './schedule.component.html',
})
export class ScheduleComponent {
    schedule: Schedule;

    constructor(private scheduleService: ScheduleService) { }

    ngOnInit(): void {
        this.scheduleService
            .getSchedule("", Date.now())
            .subscribe(response => {
                this.schedule = response
            });
    }
}