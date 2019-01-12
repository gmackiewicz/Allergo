import { Component } from '@angular/core';
import { HomeService } from '../../services/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
    constructor(private homeService: HomeService) { }

    ngOnInit() {
        this.homeService.getDashboardData().subscribe(result => console.log(result));
    }
}
