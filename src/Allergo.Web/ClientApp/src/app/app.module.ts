/* MODULES */
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from './material.module'; 

/* COMPONENTS */
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component'
import { RegisterComponent } from './components/register/register.component';

import { UsersComponent } from './components/admin/users/users.component';
import { EditUserComponent } from './components/admin/edit-user/edit-user.component';
import { AdminComponent } from './components/admin/admin/admin.component';
import { ScheduleComponent } from './components/admin/schedule/schedule.component';

/* SERVICES ANT UTILS */
import { AuthService } from './services/auth.service';
import { UsersService } from './services/users.service';
import { ScheduleService } from './services/schedule.service';
import { JwtUtil } from './utils/jwt.util';
import { AuthGuard } from './utils/authGuard.util';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    UsersComponent,
    EditUserComponent,
    AdminComponent,
    ScheduleComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
      { path: 'admin/users', component: UsersComponent, canActivate: [AuthGuard] },
      { path: 'admin/user/:id', component: EditUserComponent, canActivate: [AuthGuard] },
      { path: 'admin/schedule', component: ScheduleComponent, canActivate: [AuthGuard] }
    ]),
    HttpClientModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  providers: [
    AuthService,
    UsersService,
    ScheduleService,
    JwtUtil,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
