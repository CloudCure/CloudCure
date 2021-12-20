import { Component, OnInit, Inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public auth0:AuthService, @Inject(DOCUMENT) public document: Document, public router:Router) { }

  ngOnInit(): void {
  }

  login()
  {
    this.auth0.loginWithRedirect();
  }
  profile()
  {
    this.router.navigateByUrl("/profile");
  }
}
