import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Patient } from '../AngularModels/Patient';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EmployeeInformation } from '../AngularModels/EmployeeInformation'
import { PatientService } from '../services/patient.service';
import { AuthService } from '@auth0/auth0-angular';
import { EmployeeService } from '../services/employee.service';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-docsearch',
  templateUrl: './docsearch.component.html',
  styleUrls: ['./docsearch.component.css']
})
export class DocsearchComponent implements OnInit, OnDestroy {
  patientSearchGroup: FormGroup = new FormGroup({
    FirstName: new FormControl("", Validators.required),
    LastName: new FormControl("", Validators.required),
    Specialization: new FormControl("", Validators.required)
  })

  fullDoctorList: EmployeeInformation[] = [];
  doctorList: EmployeeInformation[] = [];
  role: number = 0;
  nurse: string = '';

  constructor(public auth0: AuthService, public router: Router, public employeeAPI: EmployeeService, @Inject(DOCUMENT) public document: Document, private patientAPI: PatientService) {
    this.employeeAPI.GetAll().subscribe(
      (response) => {
        // this.doctorList = response;
        this.fullDoctorList = response;
        for (var i in this.fullDoctorList) {
          if (this.fullDoctorList[i].userProfile.roleId == 2) {
            this.doctorList.push(this.fullDoctorList[i])

          }
        }
        console.log(this.doctorList);
      }
    )
    // checks if user is currently logged into auth0.
    this.auth0.user$.subscribe(
      (user) => {
        console.log(user);
        if (user) {
          // search database for user.email
          this.employeeAPI.verifyEmployee(user.email).subscribe(
            (response) => {
              this.role = response.userProfile.roleId;
              console.log(response);
              if (!response) {
                // send them to register page if they arent currently a user in our db.
                this.router.navigateByUrl("/register");
              }
            }
          )
        }
      }
    )
  }
  ngOnDestroy(): void {
    this.patientAPI.assigningDoctor = false;
  }

  ngOnInit(): void {
    if (this.patientAPI.assigningDoctor) {
      this.nurse = 'nurseSelect'
    }
  }

  newPatient() {
    this.router.navigateByUrl("/patient");
  }

  searchPatient(patientSearchGroup: FormGroup) {
    let search =
    {
      firstName: patientSearchGroup.get("FirstName")?.value.toLowerCase(),
      lastName: patientSearchGroup.get("LastName")?.value.toLowerCase(),
      specialization: patientSearchGroup.get("Specialization")?.value.toLowerCase()
    }
    let firstNameSearch = (search: any) => this.doctorList.filter(({ userProfile }) => userProfile.firstName.toLowerCase().includes(search.firstName))
    let lastNameSearch = (search: any) => this.doctorList.filter(({ userProfile }) => userProfile.lastName.toLowerCase().includes(search.lastName))
    let specializationSearch = (search: any) => this.doctorList.filter(({ specialization }) => specialization.toLowerCase().includes(search.specialization))
    if (search.firstName === '' && search.lastName === '' && search.specialization === '') {
      this.doctorList = this.fullDoctorList;
    }
    else {
      this.doctorList = firstNameSearch(search);
      this.doctorList = lastNameSearch(search);
      this.doctorList = specializationSearch(search);
    }
  }
}
