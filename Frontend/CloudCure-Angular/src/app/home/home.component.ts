import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public auth0: AuthService, @Inject(DOCUMENT) public document: Document, public router: Router, public employeeAPI: EmployeeService ) 
  { 
    // checks if user is currently logged into auth0.
    this.auth0.user$.subscribe(
      (user) => {
        console.log(user);
        if (user)
        {
          // search database for user.email
          this.employeeAPI.verifyEmployee(user.email).subscribe(
            (response) => 
            {
              console.log(response);
              if (!response)
              {
                // send them to register page if they arent currently a user in our db.
                this.router.navigateByUrl("/register");
              }
            }
          )          
        }
      }
    )
  }

  ngOnInit(): void {
  }

}
