import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { Patient } from '../AngularModels/Patient';
import { EmployeeService } from '../services/employee.service';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  patientSearchGroup:FormGroup = new FormGroup({
    FirstName: new FormControl("", Validators.required),
    LastName: new FormControl("", Validators.required)
  })
  fullPatientList:Patient[] = [];
  patientList:Patient[] = [];
  role:number = 0;
  constructor(public auth0: AuthService, @Inject(DOCUMENT) public document: Document, public router: Router, public employeeAPI: EmployeeService, private patientAPI: PatientService ) 
  { 
    console.log(this.patientAPI.currentPatientId);
    this.patientAPI.GetAll().subscribe(
      (response) => {
        this.patientList = response;
        this.fullPatientList = response;
        console.log(this.patientList);
      }
    )
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
              this.role = response.userProfile.roleId;
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

  newPatient(){
    this.router.navigateByUrl("/patient");
  }
  searchPatient(patientSearchGroup: FormGroup)
  {
    let search = 
    {
      firstName: patientSearchGroup.get("FirstName")?.value.toLowerCase(),
      lastName: patientSearchGroup.get("LastName")?.value.toLowerCase()
    }
    let firstNameSearch = (search:any) => this.patientList.filter(({ userProfile }) => userProfile.firstName.toLowerCase().includes(search.firstName))
    let lastNameSearch = (search: any) => this.patientList.filter(({ userProfile }) => userProfile.lastName.toLowerCase().includes(search.lastName))
    if (search.firstName === '' && search.lastName === ''){
      this.patientList = this.fullPatientList;
    }
    else
    {
      this.patientList = firstNameSearch(search);
      this.patientList = lastNameSearch(search);
    }
  }
}
