import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Condition } from '../AngularModels/Condition';
import { ConditionService } from '../services/condition.service';

@Component({
  selector: 'diagnosis-condition',
  templateUrl: './diagnosis-condition.component.html',
  styleUrls: ['./diagnosis-condition.component.css']
})
export class DiagnosisConditionComponent implements OnInit {

  display: boolean = false;
  conditions: string[] = [''];

  ConditionGroup: FormGroup = new FormGroup({
    PatientId: new FormControl(2,Validators.required),//is hardcoded to patient 2 this will change once it is connected to the diagnosis component
    ConditionName: new FormControl("",Validators.required),
  })

  constructor(private Condition: Condition, private ConditionApi: ConditionService) { }

  ngOnInit(): void {
  }

  AddCondition(ConditionGroup: FormGroup){
    if(ConditionGroup.valid)
    {
      let ConditionInfo: Condition = {
        PatientId: ConditionGroup.get("PatientId")?.value,
        ConditionName: ConditionGroup.get("ConditionName")?.value,
      }

      this.ConditionApi.Add(ConditionInfo).subscribe(
          (response) => {
            console.log("Condition added");
            console.log(response);
          })
    }
  }

}
