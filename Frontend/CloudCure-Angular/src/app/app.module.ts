import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from '@auth0/auth0-angular';
import { RouterModule } from '@angular/router';
import { BodyClickerComponent } from './body-clicker/body-clicker.component';
import { LoginComponent } from './login/login.component';
import { DiagnosisComponent } from './diagnosis/diagnosis.component';
import { PrintComponent } from './print/print.component';
import { DarkmodeDirective } from './directives/darkmode.directive';
import { DiagnosisConditionComponent } from './diagnosis-condition/diagnosis-condition.component';
import { DiagnosisVitalsComponent } from './diagnosis-vitals/diagnosis-vitals.component';
import { AssessmentComponent } from './assessment/assessment.component';
import { DiagnosisAllergyComponent } from './diagnosis-allergy/diagnosis-allergy.component';
import { TextBoxComponent } from './text-box/text-box.component';
import { VerificationComponent } from './verification/verification.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ProfileComponent } from './profile/profile.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { BottomNavbarComponent } from './bottom-navbar/bottom-navbar.component';
import { DiagnosisSurgeriesComponent } from './diagnosis-surgeries/diagnosis-surgeries.component';
import { DiagnosisMedicationComponent } from './diagnosis-medication/diagnosis-medication.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { FormControl, FormControlName,ReactiveFormsModule, FormGroup, Validators, FormsModule } from '@angular/forms';
import { PatientComponent } from './patient/patient.component';

@NgModule({
  declarations: [
    AppComponent,
    BodyClickerComponent,
    LoginComponent,
    DiagnosisComponent,
    PrintComponent,
    DarkmodeDirective,
    DiagnosisVitalsComponent,
    AssessmentComponent,
    DiagnosisAllergyComponent,
    TextBoxComponent,
    DiagnosisConditionComponent,
    // patientdiagnosis,

    DiagnosisVitalsComponent,
    VerificationComponent,
    NavbarComponent,
    HomeComponent,
    ProfileComponent,
    HeaderComponent,
    FooterComponent,
    BottomNavbarComponent,
    DiagnosisSurgeriesComponent,
    DiagnosisMedicationComponent,
    RegisterComponent,
    PatientComponent
  ],

  imports: [
    HttpClientModule,
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    AuthModule.forRoot({
      domain: 'dev-3g3556dl.us.auth0.com',
      clientId: '94k7PrpFZ7oxQEUcZk6KzDSnPOYcw1Vq'
    }),
    RouterModule.forRoot([
      { path: "verification", component: VerificationComponent },
      { path: "profile", component: ProfileComponent },
      { path: 'diagnosis', component: DiagnosisComponent },
      { path: 'print', component: PrintComponent },
      { path: 'body-clicker', component: BodyClickerComponent },
      { path: 'diagnosis-condition', component:DiagnosisConditionComponent},
      { path: 'diagnosis-vitals', component: DiagnosisVitalsComponent },
      { path: 'assessment', component: AssessmentComponent },
      { path: 'diagnosis-allergy', component: DiagnosisAllergyComponent },
      { path: 'text-box', component: TextBoxComponent },
      { path: 'register', component:RegisterComponent},
      { path: 'patient', component: PatientComponent },
      { path: "**", component: HomeComponent }
    ])
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
