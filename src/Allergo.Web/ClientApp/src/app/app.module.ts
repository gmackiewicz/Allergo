/* MODULES */
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from './material.module';
import { registerLocaleData } from '@angular/common';
import localePl from '@angular/common/locales/pl';
registerLocaleData(localePl);

/* COMPONENTS */
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component'
import { RegisterComponent } from './components/register/register.component';
import { AppointmentsComponent } from './components/appointments/appointments.component';
import { SetAppointmentComponent } from './components/appointments/set-appointment/set-appointment.component';
import { RemoveAppointmentComponent } from './components/appointments/remove-appointment/remove-appointment.component';
import { DiagnosisComponent } from './components/diagnosis/diagnosis.component';
import { SetDiagnosisComponent } from './components/admin/set-diagnosis/set-diagnosis.component';

import { UsersComponent } from './components/admin/users/users.component';
import { EditUserComponent } from './components/admin/edit-user/edit-user.component';
import { ScheduleComponent } from './components/admin/schedule/schedule.component';
import { AddAdmissionHourComponent } from './components/admin/schedule/add-admission-hour/add-addmission-hour.component';
import { RemoveAdmissionHourComponent } from './components/admin/schedule/remove-admission-hour/remove-admission-hour.component';

/* SERVICES AND UTILS */
import { AuthService } from './services/auth.service';
import { UsersService } from './services/users.service';
import { ScheduleService } from './services/schedule.service';
import { DoctorService } from './services/doctor.service';
import { HomeService } from './services/home.service';

import { JwtUtil } from './utils/jwt.util';
import { RolesUtil } from './utils/roles.util';
import { AuthGuard } from './utils/authGuard.util';
import { DoctorGuard } from './utils/doctorGuard.util';
import { PatientGuard } from './utils/patientGuard.util';
import { AdminGuard } from './utils/adminGuard.util';
import { ScheduleUtil } from './utils/schedule.util';
import { DoctorUtil } from './utils/doctor.util';
import { AppointmentService } from './services/appointment.service';
import { EditDiagnosisComponent } from './components/admin/set-diagnosis/edit-diagnosis/edit-diagnosis.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    UsersComponent,
    EditUserComponent,
    ScheduleComponent,
    AppointmentsComponent,
    SetAppointmentComponent,
    RemoveAppointmentComponent,
    AddAdmissionHourComponent,
    RemoveAdmissionHourComponent,
    DiagnosisComponent,
    SetDiagnosisComponent,
    EditDiagnosisComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'appointments', component: AppointmentsComponent, canActivate: [PatientGuard] },
      { path: 'diagnosis', component: DiagnosisComponent, canActivate: [PatientGuard] },
      { path: 'admin/users', component: UsersComponent, canActivate: [AdminGuard] },
      { path: 'admin/user/:id', component: EditUserComponent, canActivate: [AdminGuard] },
      { path: 'admin/schedule', component: ScheduleComponent, canActivate: [DoctorGuard] },
      { path: 'admin/set-diagnosis', component: SetDiagnosisComponent, canActivate: [DoctorGuard] }
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
    DoctorService,
    AppointmentService,
      { provide: LOCALE_ID, useValue: 'pl-PL' },
    HomeService,
    JwtUtil,
    RolesUtil,
    AuthGuard,
    AdminGuard,
    DoctorGuard,
    PatientGuard,
    ScheduleUtil,
    DoctorUtil
  ],
  entryComponents: [
    SetAppointmentComponent,
    RemoveAppointmentComponent,
    AddAdmissionHourComponent,
    RemoveAdmissionHourComponent,
    EditDiagnosisComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
