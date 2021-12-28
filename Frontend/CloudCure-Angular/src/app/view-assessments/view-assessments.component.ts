import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AssessmentService } from '../services/assessement.service';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-view-assessments',
  templateUrl: './view-assessments.component.html',
  styleUrls: ['./view-assessments.component.css'],
})
export class ViewAssessmentsComponent implements OnInit {

  AssessmentId: any = 1;
  DiagnosisId: any = 1;
  ChiefComplaint: any = '';
  HistoryOfPresentIllness: any = '';
  PainAssessment: any = '';
  PainScale: any = 1;
  EncounterDate: any = '';

  @Input()
  PatientId:number=0;
  ConditionName?:string;
  listOfAssesments:any[]=[];

  constructor(
    private assessmentApi: AssessmentService,
    private route: ActivatedRoute,
    private patientApi: PatientService) 
  {

  }

  ngOnInit(): void {}
}
