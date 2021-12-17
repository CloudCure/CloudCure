import { Component, OnInit } from '@angular/core';

import { Surgery } from '../AngularModels/Surgery';
import { SurgeryService } from '../services/surgery.service';

import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'diagnosis-surgeries',
  templateUrl: './diagnosis-surgeries.component.html',
  styleUrls: ['./diagnosis-surgeries.component.css']
})
export class DiagnosisSurgeriesComponent implements OnInit {
  
  //Creates a form group for Surgery Model
  //SurgeryGroup:FormGroup = new FormGroup({
  //    PatientId : new FormControl(2, Validators.required),        //Hardcoded to surgery 2 will change once it gets connected to diagnosis component
  //    SurgeryName : new FormControl("", Validators.required),      //From Surgery Model
  //});
  
  display: boolean = false;
  surgeries: string[] = [''];

  constructor(private SurgeryApi: SurgeryService) { }

  ngOnInit(): void {
  }

  public SetDataFromChild(data:any){
    this.surgeries = data;
  }

  AddSurgery(PatientId: number)
  {
    this.surgeries.forEach(element => {
      let SurgeryInfo: Surgery = {
        PatientId: PatientId,
        SurgeryName: element,
      }
      console.log(element);

      this.SurgeryApi.Add(SurgeryInfo).subscribe(
      (response) => {
        console.log("Surgery added");
        console.log(response);
      })
    });
  }

}
