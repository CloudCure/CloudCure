import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
//import { Console } from 'console';
import { Assessment } from '../AngularModels/Assessment';
import { Diagnosis } from '../AngularModels/Diagnosis';
import { Patient } from '../AngularModels/Patient';
import { Vitals } from '../AngularModels/Vitals';
import { DiagnosisService } from '../services/diagnosis.service';
import { PatientService } from '../services/patient.service';

@Component({
    selector: 'app-finalized-diagnosis-view',
    templateUrl: './finalized-diagnosis-view.component.html',
    styleUrls: ['./finalized-diagnosis-view.component.css']
})
export class FinalizedDiagnosisViewComponent implements OnInit {

    patient: Patient = {} as Patient
    daignosisId: number = 0
    diagnosis: Diagnosis = {} as Diagnosis

    constructor(private DiagnosisApi: DiagnosisService, private PatientAPI: PatientService, private router: Router) {
        this.PatientAPI.GetById(this.PatientAPI.currentPatientId).subscribe(result => {
            this.patient = result
            this.daignosisId = this.PatientAPI.diagnosisId
            console.log(this.patient)
            console.log(this.daignosisId)
            for (let diag of this.patient.diagnoses!){
                if (diag.id == this.daignosisId){
                    this.diagnosis = diag
                    break
                }
            }
            console.log(this.diagnosis)
        })
    }

    ngOnInit(): void {
    }

    backToPatientView()
    {
        this.router.navigateByUrl('/patient-view');
    }
}
