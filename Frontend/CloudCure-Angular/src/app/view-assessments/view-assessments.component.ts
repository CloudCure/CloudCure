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
    private patientApi: PatientService
  ) {
    // this.assessmentApi.getAssessments(this.patientApi.currentPatientId).subscribe((response) => {
    //   console.log(response);
    //   this.AssessmentId = response.id;
    //   this.DiagnosisId = response.diagnosisId;
    //   this.ChiefComplaint = response.chiefComplaint;
    //   this.HistoryOfPresentIllness = response.historyOfPresentIllness;
    //   this.PainAssessment = response.painAssessment;
    //   this.PainScale = response.painScale;
    //   this.EncounterDate = response.encounterDate;
    // });
    //   response.forEach(element =>
    //     {
    //       this.listOfAssesments.push(element);
    //     });
    

    // })
      // this.AssessmentId = response.id;
      // this.ChiefComplaint = response.chiefComplaint;
      // this.HistoryOfPresentIllness = response.historyOfPresentIllness;
      // this.PainAssessment = response.painAssessment;
      // this.PainScale = response.painScale;
      // this.EncounterDate = response.encounterDate;
      // this.PatientId = response.patientI
  }

  ngOnInit(): void {}
}
