import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AssessmentService } from '../services/assessement.service';

@Component({
  selector: 'app-view-assessments',
  templateUrl: './view-assessments.component.html',
  styleUrls: ['./view-assessments.component.css'],
})
export class ViewAssessmentsComponent implements OnInit {
  AssessmentId: any = 1;
  PatientId: any = 1;
  ChiefComplaint: any = '';
  HistoryOfPresentIllness: any = '';
  PainAssessment: any = '';
  PainScale: any = 1;
  EncounterDate: any = '';

  constructor(
    private assessmentService: AssessmentService,
    private route: ActivatedRoute
  ) {
    this.assessmentService.GetById(1).subscribe((response) => {
      console.log(response);
      this.AssessmentId = response.id;
      this.PatientId = response.patientId;
      this.ChiefComplaint = response.chiefComplaint;
      this.HistoryOfPresentIllness = response.historyOfPresentIllness;
      this.PainAssessment = response.painAssessment;
      this.PainScale = response.painScale;
      this.EncounterDate = response.encounterDate;
    });
  }

  ngOnInit(): void {}
}
