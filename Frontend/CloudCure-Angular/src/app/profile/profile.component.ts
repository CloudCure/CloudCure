import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { UserProfile } from '../AngularModels/UserProfile';
import { UserProfileService } from '../services/profile.service';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  user:UserProfile | null= {
    FirstName: "",
    LastName: "",
    DateOfBirth: "",
    PhoneNumber: "",
    Address: "",
    EmergencyName: "",
    EmergencyContactPhone: "",
    RoleId: 0,
    id: 0

  };

  constructor(public auth0:AuthService, service:UserProfileService) {
    //this.user = service.GetById();
  }

  ngOnInit(): void {
  }
  // changes tabs in main card
  id:any= "dashboard";
  tabChange(ids:any){
    this.id = ids;
  }
}
