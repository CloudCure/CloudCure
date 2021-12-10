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
import { DiagnosisVitalsComponent } from './diagnosis-vitals/diagnosis-vitals.component';

import { VerificationComponent } from './verification/verification.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ProfileComponent } from './profile/profile.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { ProfileService } from './services/profile.service';
import { BottomNavbarComponent } from './bottom-navbar/bottom-navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    BodyClickerComponent,
    LoginComponent,
    DiagnosisComponent,
    PrintComponent,
    DarkmodeDirective,
    DiagnosisVitalsComponent,
    VerificationComponent,
    NavbarComponent,
    ProfileComponent,
    HeaderComponent,
    FooterComponent,
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
      {path: "profile", component:ProfileComponent},
      { path: '', component: LoginComponent },
      { path: 'diagnosis', component: DiagnosisComponent },
      { path: 'print', component: PrintComponent },
      { path: 'body-clicker', component: BodyClickerComponent },
      { path: 'diagnosis-vitals', component: DiagnosisVitalsComponent },
    ])
  ],
  providers: [
    ProfileService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
