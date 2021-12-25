import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { Assessment } from '../AngularModels/Assessment';
import { Clickable } from '../AngularModels/Clickable';
import { Patient } from '../AngularModels/Patient';
import { AssessmentService } from '../services/assessement.service';
import { PatientService } from '../services/patient.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-assessment',
  templateUrl: './assessment.component.html',
  styleUrls: ['./assessment.component.css'],
})
export class AssessmentComponent implements OnInit {
  isUpdated: boolean = false;

  chiefComplaint: string = '';

  //variables
  public textAreaForm = FormGroup;
  pAssessment: Assessment[] = [];
  showBodyClicker: boolean = true;
  messageService: any;
  HideStuff: string="top-margin";
  
  date: string = new Date().toISOString().split('T')[0];
  //patientAssessment
  patientAssesment: Assessment = {
    diagnosisId: 1,
    chiefComplaint: '',
    historyOfPresentIllness: '',
    painAssessment: '',
    painScale: 0,
  };

  assessmentGroup:FormGroup = new FormGroup({
    history: new FormControl("", Validators.required),
    painAssessment: new FormControl("", Validators.required),
    painScale: new FormControl("", Validators.required),
    Date: new FormControl(new Date().toISOString().split('T')[0], Validators.required)
  })

  bodyClickButtonText: string = 'Hide Selector'

  patient: Patient = {} as Patient;
  diagnosisId: number = 0;

  constructor(
    private assessmentApi: AssessmentService,
    private patientApi: PatientService,
    private route: ActivatedRoute, private router: Router
  ) {
    this.patientApi.GetById(this.patientApi.currentPatientId).subscribe(
      (response) => {
        this.patient = response;
        this.diagnosisId = this.patient.diagnoses![this.patient.diagnoses!.length - 1].id
      }
    )
    
  }

  ngOnInit(): void {
  }

  show()
  {
    this.showBodyClicker = !this.showBodyClicker;
    if (this.showBodyClicker) {
      this.bodyClickButtonText = "Hide Selector"
    }
    if (!this.showBodyClicker) {
      this.bodyClickButtonText = "Show Selector"
    }
    if (this.HideStuff === "top-margin")
    {
      this.HideStuff = "";
    }
    else{
      this.HideStuff = "top-margin";
    }
  }

  //Add assessment
  AddAsssessment() {
    
  }

  onSubmit(assessmentGroup:FormGroup) {
    if (assessmentGroup.valid)
    {
      this.patientAssesment.diagnosisId = this.diagnosisId;
      this.patientAssesment.chiefComplaint = this.clickedPartsConverter();
      this.patientAssesment.historyOfPresentIllness = assessmentGroup.get("history")?.value;
      this.patientAssesment.painScale = assessmentGroup.get("painScale")?.value;
      this.patientAssesment.painAssessment = assessmentGroup.get("painAssessment")?.value;
      this.patientAssesment.encounterDate = assessmentGroup.get("Date")?.value;
      this.assessmentApi.Add(this.patientAssesment).subscribe((response) => {
        console.log(response);
      });
    }
    this.router.navigateByUrl("home");
  }


  //Body Clicker
  clickedParts: string[] = [];

  getClick(bodypart: Clickable) {
    console.log(`Clicked on ${bodypart.name}`);

    if (this.clickedParts.find((x) => x === bodypart.name)) {
      this.clickedParts.splice(this.clickedParts.indexOf(bodypart.name!), 1);
    } else {
      this.clickedParts.push(bodypart.name!);
    }
    console.log(this.clickedParts);
  }
  clickedPartsConverter() {
    return this.clickedParts.join(', ');
  }
}