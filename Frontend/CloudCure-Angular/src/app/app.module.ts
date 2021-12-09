import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormControl, FormControlName,ReactiveFormsModule, FormGroup, Validators, FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { BodyClickerComponent } from './body-clicker/body-clicker.component';
import { LoginComponent } from './login/login.component';
import { DiagnosisComponent } from './diagnosis/diagnosis.component';
import { PrintComponent } from './print/print.component';
import { DarkmodeDirective } from './directives/darkmode.directive';
import { AngularModelsComponent } from './angular-models/angular-models.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    BodyClickerComponent,
    LoginComponent,
    DiagnosisComponent,
    PrintComponent,
    DarkmodeDirective,
    AngularModelsComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
