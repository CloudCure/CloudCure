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

  chiefComplaint: string = '';

  //variables
  public textAreaForm = FormGroup;
  pAssessment: Assessment[] = [];
  showBodyClicker: boolean = true;
  messageService: any;

  //patientAssessment
  patientAssesment: Assessment = {
    ChiefComplaint: '',
    HistOfPresentIllness: '',
    PainAssessment: '',
    PainScale: 0,
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
  }

  //Add assessment
  AddAsssessment() {
    this.patientService.Add(this.patientAssesment).subscribe(
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
    this.patientService.Add(this.patientAssesment).subscribe(
      (result) => console.log('success ', result),
      (error) => console.log('error ', error)
    );
  }
  //Body Clicker

  getClick(bodypart: Clickable) {
    this.chiefComplaint += bodypart.name + ', ';
    console.log(this.chiefComplaint);
  }

  send() {
    console.log(this.patientAssesment);
  }
}
