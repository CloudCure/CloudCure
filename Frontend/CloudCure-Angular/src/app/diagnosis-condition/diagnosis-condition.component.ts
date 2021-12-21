import { Component, OnInit } from '@angular/core';
import { Condition } from '../AngularModels/Condition';
import { ConditionService } from '../services/condition.service';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'diagnosis-condition',
  templateUrl: './diagnosis-condition.component.html',
  styleUrls: ['./diagnosis-condition.component.css']
})
export class DiagnosisConditionComponent implements OnInit {

  display: boolean = true;
  conditions: string[] = [""];
  PatientID: number = this.patientAPI.currentPatientId!;

 
  constructor(private ConditionApi: ConditionService, private patientAPI:PatientService) {}
  
  ngOnInit(): void {}
  
  public SetDataFromChild(data:any){
    this.conditions = data;
  }

  AddCondition(PatientId: number){
    this.conditions.forEach(element => {
      let ConditionInfo: Condition = {
        PatientId: PatientId,
        ConditionName: element,
      }
      console.log(element);

      this.ConditionApi.Add(ConditionInfo).subscribe(
      (response) => {
        console.log("Condition added");
        console.log(response);
      })
    });
  }

}
