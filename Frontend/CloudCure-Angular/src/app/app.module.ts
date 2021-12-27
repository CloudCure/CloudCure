import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from '@auth0/auth0-angular';
import { RouterModule } from '@angular/router';
import { BodyClickerComponent } from './body-clicker/body-clicker.component';
import { LoginComponent } from './login/login.component';
import { PrintComponent } from './print/print.component';
import { DarkmodeDirective } from './directives/darkmode.directive';
import { DiagnosisVitalsComponent } from './diagnosis-vitals/diagnosis-vitals.component';
import { AssessmentComponent } from './assessment/assessment.component';
import { TextBoxComponent } from './text-box/text-box.component';
import { VerificationComponent } from './verification/verification.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ProfileComponent } from './profile/profile.component';
import { BottomNavbarComponent } from './bottom-navbar/bottom-navbar.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import {
  FormControl,
  FormControlName,
  ReactiveFormsModule,
  FormGroup,
  Validators,
  FormsModule,
} from '@angular/forms';
import { AuthGuardService } from './services/auth-guard.service';
import { PatientComponent } from './patient/patient.component';
import { PatientViewComponent } from './patient-view/patient-view.component';
import { ListPatientComponent } from './list-patient/list-patient.component';
import { DocsearchComponent } from './docsearch/docsearch.component';
import { ListDoctorComponent } from './list-doctor/list-doctor.component';
import { ViewDiagnosisComponent } from './view-diagnosis/view-diagnosis.component';
import { VitalsviewComponent } from './vitalsview/vitalsview.component';
import { ViewConditionsComponent } from './view-conditions/view-conditions.component';
import { ViewAssessmentsComponent } from './view-assessments/view-assessments.component';
import { ViewAllergiesComponent } from './view-allergies/view-allergies.component';
import { ViewMedicationsComponent } from './view-medications/view-medications.component';
import { ViewSurgeriesComponent } from './view-surgeries/view-surgeries.component';
import { FinalizedDiagnosisViewComponent } from './finalized-diagnosis-view/finalized-diagnosis-view.component';
import { UpdateUserInfoComponent } from './update-user-info/update-user-info.component';

@NgModule({
  declarations: [
    AppComponent,
    BodyClickerComponent,
    LoginComponent,
    PrintComponent,
    DarkmodeDirective,
    DiagnosisVitalsComponent,
    AssessmentComponent,
    TextBoxComponent,
    FinalizedDiagnosisViewComponent,
    // patientdiagnosis,
    DiagnosisVitalsComponent,
    VerificationComponent,
    NavbarComponent,
    HomeComponent,
    ProfileComponent,
    BottomNavbarComponent,
    RegisterComponent,
    PatientComponent,
    ListPatientComponent,
    ViewDiagnosisComponent,
    PatientViewComponent,
    VitalsviewComponent,
    DocsearchComponent,
    ListDoctorComponent,
    ViewDiagnosisComponent,
    ViewConditionsComponent,
    ViewAssessmentsComponent,
    ViewAllergiesComponent,
    ViewMedicationsComponent,
    ViewSurgeriesComponent,
    UpdateUserInfoComponent,

  ],

  imports: [
    HttpClientModule,
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    AuthModule.forRoot({
      domain: 'dev-3g3556dl.us.auth0.com',
      clientId: '94k7PrpFZ7oxQEUcZk6KzDSnPOYcw1Vq',
      cacheLocation: 'localstorage',
      useRefreshTokens: true,
    }),
    RouterModule.forRoot([
      //canActivate:[AuthGuardService] means that log-in required in order to hit this route
      {
        path: 'verification',
        component: VerificationComponent,
        canActivate: [AuthGuardService],
      },
      {
        path: 'profile',
        component: ProfileComponent,
        canActivate: [AuthGuardService],
      },
      {
        path: 'print',
        component: PrintComponent,
        canActivate: [AuthGuardService],
      },
      {
        path: 'body-clicker',
        component: BodyClickerComponent /*canActivate:[AuthGuardService]*/,
      },
      {
        path: 'diagnosis-vitals',
        component: DiagnosisVitalsComponent /*canActivate:[AuthGuardService]*/,
      },
      {
        path: 'assessment',
        component: AssessmentComponent /*canActivate:[AuthGuardService]*/,
      },
      {
        path: 'view-assessments',
        component: ViewAssessmentsComponent /*canActivate:[AuthGuardService]*/,
      },
      {
        path: 'text-box',
        component: TextBoxComponent,
        canActivate: [AuthGuardService],
      },
      {
        path: 'patient',
        component: PatientComponent /*canActivate:[AuthGuardService]*/,
      },
      {
        path: 'view-diagnosis',
        component: ViewDiagnosisComponent,
        canActivate: [AuthGuardService],
      },
      {
        path: 'patient-view',
        component: PatientViewComponent /*canActivate:[AuthGuardService]*/,
      },
      { path: 'finalized-diagnosis-view', component: FinalizedDiagnosisViewComponent },
      { path: 'view-conditions', component: ViewConditionsComponent },
      { path: 'UpdateUserInfo', component: UpdateUserInfoComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'search', component: DocsearchComponent },
      { path: 'home', component: HomeComponent },
      { path: '**', component: HomeComponent },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
