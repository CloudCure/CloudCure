import { AfterViewInit, Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Condition } from '../AngularModels/Condition';
import { ConditionService } from '../services/condition.service';
import { TextBoxComponent } from '../text-box/text-box.component';

@Component({
  selector: 'diagnosis-condition',
  templateUrl: './diagnosis-condition.component.html',
  styleUrls: ['./diagnosis-condition.component.css']
})
export class DiagnosisConditionComponent implements OnInit {

  display: boolean = false;
  conditions: string[] = ["test"]
  ////////////////////////////////////
  test:string = "Can You See ME"
  ///////////////////////////////////////////
 
  constructor(private ConditionApi: ConditionService) {
    
   }

  ngOnInit(): void {
  }
  //////////////////////////////////////////////
  public SetDataFromChild(data:any){
    // this.test=data 
    console.log("Data received?")
    this.conditions = data;
  }
  //////////////////////////////////////////////
  AddCondition(PatientId: number){
    this.conditions.forEach(element => {
      let ConditionInfo: Condition = {
        PatientId: PatientId,
        ConditionName: element,
      }
      console.log(this.conditions);

      // this.ConditionApi.Add(ConditionInfo).subscribe(
      //   (response) => {
      //     console.log("Condition added");
      //     console.log(response);
      //   })
       });

      
        
  

    // if(ConditionGroup.valid)
    // {
    //   let ConditionInfo: Condition = {
    //     PatientId: ConditionGroup.get("PatientId")?.value,
    //     ConditionName: ConditionGroup.get("ConditionName")?.value,
    //   }

    //   this.ConditionApi.Add(ConditionInfo).subscribe(
    //       (response) => {
    //         console.log("Condition added");
    //         console.log(response);
    //       })
    // }
  }



}
