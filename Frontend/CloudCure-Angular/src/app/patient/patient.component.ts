import { Component, OnInit } from '@angular/core';

import { Patient } from '../AngularModels/Patient';
import { User } from '@auth0/auth0-angular';
import { PatientService } from '../services/patient.service';
import { UserService } from '../services/user.service';

import { FormControl, FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { UserProfile } from '../AngularModels/UserProfile';
import { Router } from '@angular/router';
import { ConditionService } from '../services/condition.service';
import { Condition } from '../AngularModels/Condition';
import { AllergyService } from '../services/allergy.service';
import { Allergy } from '../AngularModels/Allergy';
import { SurgeryService } from '../services/surgery.service';
import { Surgery } from '../AngularModels/Surgery';
import { MedicationService } from '../services/medication.service';
import { Medication } from '../AngularModels/Medication';
import { ClassGetter } from '@angular/compiler/src/output/output_ast';


@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {

  //Creates a form group for the User model 
  registerGroup: FormGroup = new FormGroup({
    FirstName: new FormControl("", Validators.required),              //from UserProfile model
    LastName: new FormControl("", Validators.required),               //from UserProfile model
    DateOfBirth: new FormControl("", Validators.required),            //from UserProfile model
    PhoneNumber: new FormControl("", Validators.required),            //from UserProfile model
    Address: new FormControl("", Validators.required),                //from UserProfile model
    EmergencyName: new FormControl("", Validators.required),          //from UserProfile model
    EmergencyContactPhone: new FormControl("", Validators.required),  //from UserProfile model
    UserRole: new FormControl(3, Validators.required),                //from UserProfile model
    conditions: this.formBuilder.array([]),
    allergies: this.formBuilder.array([]),
    surgeries: this.formBuilder.array([]),
    medications: this.formBuilder.array([])
  });
  get FirstName() { return this.registerGroup.get("FirstName"); }
  get LastName() { return this.registerGroup.get("LastName"); }
  get DateOfBirth() { return this.registerGroup.get("DateOfBirth"); }
  get PhoneNumber() { return this.registerGroup.get("PhoneNumber"); }
  get Address() { return this.registerGroup.get("Address"); }
  get EmergencyName() { return this.registerGroup.get("EmergencyName"); }
  get EmergencyContactPhone() { return this.registerGroup.get("EmergencyContactPhone"); }

  date: Date = new Date;
  offset = this.date.getTimezoneOffset();
  today: string = "";
  // conditionForm: FormGroup;

  constructor(private PatientApi: PatientService,
    private UserApi: UserService,
    private conditionApi: ConditionService,
    private allergyApi: AllergyService,
    private surgeryApi: SurgeryService,
    private medicationApi: MedicationService,
    private router: Router,
    private formBuilder: FormBuilder) 
    {
    this.date = new Date(this.date.getTime() - (this.offset * 60 * 1000));
    this.today = this.date.toISOString().split('T')[0];
  }

  ngOnInit(): void {
  }

  conditions(): FormArray {
    return this.registerGroup.get('conditions') as FormArray
  }

  allergies(): FormArray {
    return this.registerGroup.get('allergies') as FormArray
  }
  surgeries(): FormArray {
    return this.registerGroup.get('surgeries') as FormArray
  }
  medications(): FormArray {
    return this.registerGroup.get('medications') as FormArray
  }

  newElement(): FormGroup {
    return this.formBuilder.group({
      text: '',
    })
  }

  addMoreElements(input: string) {
    switch (input) {
      case 'condition':
        this.conditions().push(this.newElement());
        break;
      case 'allergy':
        this.allergies().push(this.newElement());
        break;
      case 'surgery':
        this.surgeries().push(this.newElement());
        break;
      case 'medication':
        this.medications().push(this.newElement());
        break;
      default:
        break;
    }

  }

  removeElement(input: string, i: number) {
    switch (input) {
      case 'condition':
        this.conditions().removeAt(i);
        break;
      case 'allergy':
        this.allergies().removeAt(i);
        break;
      case 'surgery':
        this.surgeries().removeAt(i);
        break;
      case 'medication':
        this.medications().removeAt(i);
        break;
      default:
        break;
    }

  }

  RegisterPatient(registerGroup: FormGroup) {
    console.log("register complete")
    console.log(registerGroup);

    //valid property of a FormGroup will let you know if the Form group the user sent is valid or not
    if (registerGroup.valid) {
      let UserInfo: UserProfile = {
        firstName: registerGroup.get("FirstName")?.value,
        lastName: registerGroup.get("LastName")?.value,
        dateOfBirth: new Date(registerGroup.get("DateOfBirth")?.value).toISOString(),
        phoneNumber: registerGroup.get("PhoneNumber")?.value,
        address: registerGroup.get("Address")?.value,
        emergencyName: registerGroup.get("EmergencyName")?.value,
        emergencyContactPhone: registerGroup.get("EmergencyContactPhone")?.value,
        roleId: 3,
      }
      let PatientInfo: Patient = {
        userProfile: UserInfo,
      }
      console.log("Patient Info created");
      console.log(PatientInfo);

      this.PatientApi.Add(PatientInfo).subscribe(
        (response) => {
          console.log("Patient added");
          console.log(response);

          //Conditions
          let conditions:string[]= registerGroup.get('conditions')?.value;
          conditions = conditions.map(function (cond: any) {
            return cond['text']
          })
          conditions.forEach(element => {
            if (element !== ''){
              let conditionInfo: Condition = {
                patientId: response.id!,
                conditionName: element
              }
              console.log(conditionInfo)
              this.conditionApi.Add(conditionInfo).subscribe(
                (conditionResponse) => {
                  console.log("Condition added");
                  console.log(conditionResponse);
                }
              )
            }
          });

          //Allergies
          let allergies: string[] = registerGroup.get('allergies')?.value;
          allergies = allergies.map(function (cond: any) {
            return cond['text']
          })
          console.log(allergies)
          allergies.forEach(element => {
            if (element !== ''){
              let allergyInfo: Allergy = {
                patientId: response.id!,
                allergyName: element
              }
              console.log(allergyInfo)
              this.allergyApi.Add(allergyInfo).subscribe(
                (allergyResponse) => {
                  console.log("Allergy added");
                  console.log(allergyResponse);
                }
              )
            }
          })

          //Surgeries
          let surgeries: string[] = registerGroup.get('surgeries')?.value;
          surgeries = surgeries.map(function (cond: any) {
            return cond['text']
          })
          surgeries.forEach(element => {
            console.log(element);
            if (element !== '')
            {
              let surgeryInfo: Surgery = {
                patientId: response.id!,
                surgeryName: element
              }
              this.surgeryApi.Add(surgeryInfo).subscribe(
                (surgeryResponse) => {
                  console.log("Surgery added");
                  console.log(surgeryResponse);
                }
              )
            }
          })

          //Medication
          let medications: string[] = registerGroup.get('medications')?.value;
          medications = medications.map(function (cond: any) {
            return cond['text']
          })
          medications.forEach(element => {
            if (element !== '')
            {
              let medicationInfo: Medication = {
                patientId: response.id!,
                medicationName: element
              }
              this.medicationApi.Add(medicationInfo).subscribe(
                (medicationResponse) => {
                  console.log("medication added");
                  console.log(medicationResponse);
                }
              )
            }
          });

          this.PatientApi.currentPatientId = response.id;
          this.router.navigateByUrl("/verification");
        })

    }
    else {
      this.registerGroup.markAllAsTouched();
    }
  }
}