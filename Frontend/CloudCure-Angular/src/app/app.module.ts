import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AuthModule } from '@auth0/auth0-angular';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { BodyClickerComponent } from './body-clicker/body-clicker.component';
import { LoginComponent } from './login/login.component';
import { DiagnosisComponent } from './diagnosis/diagnosis.component';
import { PrintComponent } from './print/print.component';
import { DarkmodeDirective } from './directives/darkmode.directive';
import { VerificationComponent } from './verification/verification.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BottomNavbarComponent } from './bottom-navbar/bottom-navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    BodyClickerComponent,
    LoginComponent,
    DiagnosisComponent,
    PrintComponent,
    DarkmodeDirective,
    VerificationComponent,
    NavbarComponent,
    BottomNavbarComponent
  ],
  imports: [
    BrowserModule,
    AuthModule.forRoot({
      domain: 'dev-3g3556dl.us.auth0.com',
      clientId: '94k7PrpFZ7oxQEUcZk6KzDSnPOYcw1Vq'
    }),
    RouterModule.forRoot([
      {path: "verification", component:VerificationComponent},
    ]),
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
