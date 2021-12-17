import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Allergy } from '../AngularModels/Allergy';
import { AllergyService } from '../services/allergy.service';
import { TextBoxComponent } from '../text-box/text-box.component';

@Component({
  selector: 'diagnosis-allergy',
  templateUrl: './diagnosis-allergy.component.html',
  styleUrls: ['./diagnosis-allergy.component.css']
})
export class DiagnosisAllergyComponent implements OnInit {

  //variables
  display: boolean = false;
  allergies: string[] = [''];
  
  constructor(private AllergyApi: AllergyService) { }

  ngOnInit(): void {
  }

  public SetDataFromChild(data:any){
    this.allergies = data;
  }

  AddAllergy(PatientId: number){
    this.allergies.forEach(element => {
      let AllergyInfo: Allergy = {
        PatientId: PatientId,
        AllergyName: element,
      }
      console.log(element);

      this.AllergyApi.Add(AllergyInfo).subscribe(
        (response) => {
          console.log("Condition added");
          console.log(response);
        }
      )
    });
  }

}
