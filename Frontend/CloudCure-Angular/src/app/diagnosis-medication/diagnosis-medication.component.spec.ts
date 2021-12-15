import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiagnosisMedicationComponent } from './diagnosis-medication.component';

describe('DiagnosisMedicationComponent', () => {
  let component: DiagnosisMedicationComponent;
  let fixture: ComponentFixture<DiagnosisMedicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DiagnosisMedicationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DiagnosisMedicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
