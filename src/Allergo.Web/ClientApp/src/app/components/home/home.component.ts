import { Component } from '@angular/core';
import { HomeService } from '../../services/home.service';
import { DashboardData } from '../../models/dashboard-data.model';
import { Statistics } from '../../models/statistics.model';
import { RolesUtil } from '../../utils/roles.util';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
    constructor(private homeService: HomeService, private rolesUtil: RolesUtil) { }
    dashboardData: DashboardData = new DashboardData(new Statistics(0, 0, 0));
    ngOnInit() {
        this.homeService
            .getDashboardData()
            .subscribe(result => this.dashboardData = result);
    }
}
