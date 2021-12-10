import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './app.component';
import { BodyClickerComponent } from './body-clicker/body-clicker.component';
import { LoginComponent } from './login/login.component';
import { DiagnosisComponent } from './diagnosis/diagnosis.component';
import { PrintComponent } from './print/print.component';
import { DarkmodeDirective } from './directives/darkmode.directive';
import { DiagnosisVitalsComponent } from './diagnosis-vitals/diagnosis-vitals.component';
import { AssessmentComponent } from './assessment/assessment.component';

@NgModule({
  declarations: [
    AppComponent,
    BodyClickerComponent,
    LoginComponent,
    DiagnosisComponent,
    PrintComponent,
    DarkmodeDirective,
    DiagnosisVitalsComponent,
    AssessmentComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent },
      { path: 'diagnosis', component: DiagnosisComponent },
      { path: 'print', component: PrintComponent },
      { path: 'body-clicker', component: BodyClickerComponent },
      { path: 'diagnosis-vitals', component: DiagnosisVitalsComponent },
      { path: 'assessment', component: AssessmentComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
