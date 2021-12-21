import { Component, OnInit } from '@angular/core';
import { Medication } from '../AngularModels/Medication';
import { MedicationService } from '../services/medication.service';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'diagnosis-medication',
  templateUrl: './diagnosis-medication.component.html',
  styleUrls: ['./diagnosis-medication.component.css']
})
export class DiagnosisMedicationComponent implements OnInit {

  // variables
  display: boolean = false;
  medications: string[] = [''];
  PatientID: number = this.patientAPI.currentPatientId!;

  constructor(private MedsApi: MedicationService, private patientAPI:PatientService) { }

  ngOnInit(): void {
  }

  public SetDataFromChild(data:any){
    this.medications = data;
  }

  AddMeds(PatientId: number){
    this.medications.forEach(element => {
      let MedicationInfo: Medication = {
        PatientId: PatientId,
        MedicationName: element,
      }
      console.log(element);

      this.MedsApi.Add(MedicationInfo).subscribe(
        (response) => {
          console.log("Med added");
          console.log(response);
        }
      )
    })
  }

}
