import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiagnosisAllergyComponent } from './diagnosis-allergy.component';

describe('DiagnosisAllergyComponent', () => {
  let component: DiagnosisAllergyComponent;
  let fixture: ComponentFixture<DiagnosisAllergyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DiagnosisAllergyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DiagnosisAllergyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
