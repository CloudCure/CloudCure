import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { Assessment } from '../AngularModels/Assessment';
import { Clickable } from '../AngularModels/Clickable';
import { AssessmentService } from '../services/assessement.service';

@Component({
  selector: 'app-assessment',
  templateUrl: './assessment.component.html',
  styleUrls: ['./assessment.component.css'],
})
export class AssessmentComponent implements OnInit {
  isUpdated: boolean = false;
  patientAssessment: any = [];

  newAssessment: Assessment = {
    PatientId: 0,
    ChiefComplaint: '',
    HistOfPresentIllness: '',
  };

  //variables
  public textAreaForm = FormGroup;
  pAssessment: Assessment[] = [];
  showBodyClicker: boolean = true;
  messageService: any;

  patientAssesment: Assessment = {
    ChiefComplaint: 'Describe your complaint',
    HistOfPresentIllness: 'Describe the history of your present illness',
    PainAssessment: 'Pain assessment',
    PainScale: 5,
  };

  constructor(
    private patientService: AssessmentService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    /*
    this.textAreaForm = this.formBuilder.group({
      HistOfPresentIllness: ['', Validators.required],
      ChiefComplaint: ['', Validators.required],
      PainAssessment: ['', Validators.required],
      PainScale: [''],
    });
    */

    //get all the patient assessments
    this.patientService.GetAll().subscribe((response) => {
      this.patientAssessment = response;
      console.log(this.patientAssessment);
    });
  }

  //Add assessment
  AddAsssessment() {
    this.patientService.Add(this.newAssessment).subscribe(
      (response) => {
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Assessment is created',
        });
        console.log(response);
      },
      (error) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Assessment is not created',
        });
        console.log(error);
      }
    );
  }

  //Delete Assessment
  deleteAsssessment(Id: number) {
    this.patientService.Delete(Id).subscribe(
      (response) => {
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Assessment has been deleted',
        });
        console.log(response);
      },
      (error) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Assessment was not deleted',
        });
        console.log(error);
      }
    );
  }
  //Update Assessment
  //updateAssessment() {}

  onSubmit(form: NgForm) {
    console.log('onSubmit ', form.valid);
    this.patientService.postAssessment(this.patientAssessment).subscribe(
      (result) => console.log('success ', result),
      (error) => console.log('error ', error)
    );
  }
  //Body Clicker

  getClick(bodypart: Clickable) {
    console.log(`Clicked on ${bodypart.name}`);
  }
}
