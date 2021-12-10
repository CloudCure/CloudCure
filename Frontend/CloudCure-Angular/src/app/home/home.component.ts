import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { WebApiService } from '../services/web-api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private auth0:AuthService, private router:Router, private webApi: WebApiService ) 
  { 
    //checks if user is currently logged into auth0.
    this.auth0.user$.subscribe(
      (user) => {
        console.log(user);
        if (user)
        {
          //search database for user.email
          this.webApi.loginUser(user.email).subscribe(
            (response) => 
            {
              if (!response)
              {
                /*If user is not in database, route to register*/
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
