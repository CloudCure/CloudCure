import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeInformation } from '../AngularModels/EmployeeInformation';
import { EmployeeService } from '../services/employee.service';
import { FormControl, FormControlName,ReactiveFormsModule, FormGroup,FormBuilder, Validators } from '@angular/forms';
import { UserProfile } from '../AngularModels/UserProfile';
import { UserService } from '../services/user.service';



@Component({
  selector: 'app-update-user-info',
  templateUrl: './update-user-info.component.html',
  styleUrls: ['./update-user-info.component.css']
})
export class UpdateUserInfoComponent implements OnInit {
  currentEmployee?: EmployeeInformation = this.employeeApi.currentEmployee;
  //Creates a form group for the User model
  UpdateGroup:FormGroup = new FormGroup({
      WorkEmail: new FormControl(""),//from EmployeeInformation model
      FirstName: new FormControl(this. currentEmployee?.userProfile.firstName, Validators.required),//from UserProfile model
      LastName: new FormControl(this.currentEmployee?.userProfile.lastName, Validators.required),//from UserProfile model
      DateOfBirth: new FormControl(this.currentEmployee?.userProfile.dateOfBirth, Validators.required),//from UserProfile model
      PhoneNumber: new FormControl(this.currentEmployee?.userProfile.phoneNumber, Validators.required),//from UserProfile model
      Address: new FormControl(this.currentEmployee?.userProfile.address, Validators.required),//from UserProfile model
      EmergencyName: new FormControl(this.currentEmployee?.userProfile.emergencyName, Validators.required),//from UserProfile model
      EmergencyContactPhone: new FormControl(this.currentEmployee?.userProfile.emergencyContactPhone, Validators.required),//from UserProfile model
      Specialization: new FormControl(this.currentEmployee?.specialization, Validators.required),//from EmployeeInformation model
      StartDate: new FormControl(this.currentEmployee?.startDate, Validators.required),//from EmployeeInformation model
      EducationDegree: new FormControl(this.currentEmployee?.educationDegree, Validators.required),//from EmployeeInformation model
      RoomNumber: new FormControl(this.currentEmployee?.roomNumber, Validators.required),//from EmployeeInformation model
    UserRole: new FormControl(this.currentEmployee?.userProfile.role?.id, Validators.required),// RoleId from UserProfile model
  });
  get FirstName() {return this.UpdateGroup.get("FirstName");}
  get LastName() {return this.UpdateGroup.get("LastName");}
  get DateOfBirth() {return this.UpdateGroup.get("DateOfBirth");}
  get PhoneNumber() {return this.UpdateGroup.get("PhoneNumber");}
  get Address() {return this.UpdateGroup.get("Address");}
  get EmergencyName() {return this.UpdateGroup.get("EmergencyName");}
  get EmergencyContactPhone() {return this.UpdateGroup.get("EmergencyContactPhone");}
  get Specialization() {return this.UpdateGroup.get("Specialization");}
  get StartDate() {return this.UpdateGroup.get("StartDate");}
  get EducationDegree() {return this.UpdateGroup.get("EducationDegree");}
  get RoomNumber() {return this.UpdateGroup.get("RoomNumber");}
  get UserRole() {return this.UpdateGroup.get("UserRole");}

  employee: EmployeeInformation = {} as EmployeeInformation
  email:string | undefined = '';
  date: Date = new Date;
  offset = this.date.getTimezoneOffset();
  today:string = "";
  tele = document.querySelector('#telle');
  constructor(public employeeApi: EmployeeService, public router: Router, public UserApi: UserService) {
   
    
   }

  ngOnInit(): void {
  }

  Update(UpdateGroup: FormGroup)
  {
    if (UpdateGroup.valid) {
        let UserInfo: UserProfile = {
          firstName: UpdateGroup.get("FirstName")?.value,
          lastName: UpdateGroup.get("LastName")?.value,
          dateOfBirth: new Date(UpdateGroup.get("DateOfBirth")?.value).toISOString(),
          phoneNumber: UpdateGroup.get("PhoneNumber")?.value,
          address: UpdateGroup.get("Address")?.value,
          emergencyName: UpdateGroup.get("EmergencyName")?.value,
          emergencyContactPhone: UpdateGroup.get("EmergencyContactPhone")?.value,
          roleId: UpdateGroup.get("UserRole")?.value,
        }

        let EmployeeInfo: EmployeeInformation = {
            userProfile: UserInfo,
            workEmail: this.currentEmployee?.workEmail,
            specialization: UpdateGroup.get("Specialization")?.value,
            startDate: this.currentEmployee?.startDate,
            roomNumber: UpdateGroup.get("RoomNumber")?.value,
            educationDegree: UpdateGroup.get("EducationDegree")?.value
        }

        this.employeeApi.Update(EmployeeInfo, this.currentEmployee?.id).subscribe(
          (result) => {
            console.log("info updated")
            console.log(result)
            this.router.navigateByUrl("/profile")
          }
        )

    }
    else{
      this.UpdateGroup.markAllAsTouched();
    }
  }
}
