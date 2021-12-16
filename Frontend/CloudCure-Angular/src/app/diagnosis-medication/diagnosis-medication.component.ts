import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { Medication } from '../AngularModels/Medication';


@Component({
  selector: 'diagnosis-medication',
  templateUrl: './diagnosis-medication.component.html',
  styleUrls: ['./diagnosis-medication.component.css']
})
export class DiagnosisMedicationComponent implements OnInit {

  display: boolean = false;

  medication_names:string[] = ['Aspirin', 'Corticosteroids', 'Diphenhydramine', 'Doxycycline', 'Fluoxetine', 'Hydrocodone', 'Hydromorphone', 'Lithium', 'Methadone', 'Morphine', 'Oxycodone', 'Oxymorphone', 'Paracetamol', 'Phenobarbital', 'Phenytoin', 'Prednisone', 'Propranolol', 'Rifampin', 'Sertraline', 'Sodium Valproate', 'Tramadol', 'Valproate', 'Vitamin B', 'Vitamin C', 'Vitamin D', 'Vitamin E', 'Vitamin K', 'Zolpidem'];

  @Input('medications') medications: Medication[]|undefined = []!;

  @Output('medications') medicationsChange = new EventEmitter<Medication[]>();

  constructor() { 
    this.medications = []!;
  }

  ngOnInit(): void {
  }

}
