import { Component, OnInit, Inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public auth0:AuthService, @Inject(DOCUMENT) public document: Document) { }

  ngOnInit(): void {
  }

  login()
  {
    this.auth0.loginWithRedirect();
  }
}
