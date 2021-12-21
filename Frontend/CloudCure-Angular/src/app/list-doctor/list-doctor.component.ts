import { Component, Input, OnInit } from '@angular/core';
import { Patient } from '../AngularModels/Patient';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserProfile } from '../AngularModels/UserProfile';
import { UserService } from '../services/user.service';
import { User } from '@auth0/auth0-angular';
import { Allergy } from '../AngularModels/Allergy';
import { Router } from '@angular/router';
import { EmployeeInformation } from '../AngularModels/EmployeeInformation'
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-list-doctor',
  templateUrl: './list-doctor.component.html',
  styleUrls: ['./list-doctor.component.css']
})
export class ListDoctorComponent implements OnInit {

  @Input()
  doctor: EmployeeInformation = {} as EmployeeInformation;

  @Input()
  role: number = 0;

  constructor(private router: Router, public employeeAPI: EmployeeService) { }

  ngOnInit(): void {
  }

  allergies()
  {

  }



  finalize()
  {

  }
}
