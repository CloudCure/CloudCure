import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, FormControlName, ReactiveFormsModule } from '@angular/forms';
import { CovidService } from 'src/app/services/covid.service';
import { Router } from '@angular/router';
import { CovidVerify } from '../AngularModels/CovidVerify';



@Component({
  selector: 'app-verification',
  templateUrl: './verification.component.html',
  styleUrls: ['./verification.component.css']
})
export class VerificationComponent implements OnInit {

  verifiGroup: FormGroup = new FormGroup({
    'question1': new FormControl(),
    'question2': new FormControl(),
    'question3': new FormControl(),
    'question4': new FormControl(),
    'question5': new FormControl()
  })



  constructor(private fb: FormBuilder) {

   }

  ngOnInit(): void {

    }

    submitForm(){
      console.log(this.verifiGroup.value);
    }
  }
