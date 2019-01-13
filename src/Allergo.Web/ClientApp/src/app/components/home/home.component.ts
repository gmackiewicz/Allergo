import { Component } from '@angular/core';
import { HomeService } from '../../services/home.service';
import { DashboardData } from '../../models/dashboard-data.model';
import { Statistics } from '../../models/statistics.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
    constructor(private homeService: HomeService) { }
    dashboardData: DashboardData = new DashboardData(new Statistics(0, 0, 0));
    ngOnInit() {
        this.homeService
            .getDashboardData()
            .subscribe(result => this.dashboardData = result);
    }
}
