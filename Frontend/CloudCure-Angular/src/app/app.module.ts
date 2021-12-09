import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BodyClickerComponent } from './body-clicker/body-clicker.component';
import { LoginComponent } from './login/login.component';
import { DiagnosisComponent } from './diagnosis/diagnosis.component';
import { PrintComponent } from './print/print.component';
import { DarkmodeDirective } from './directives/darkmode.directive';
import { NavbarComponent } from './navbar/navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    BodyClickerComponent,
    LoginComponent,
    DiagnosisComponent,
    PrintComponent,
    DarkmodeDirective,
    NavbarComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
