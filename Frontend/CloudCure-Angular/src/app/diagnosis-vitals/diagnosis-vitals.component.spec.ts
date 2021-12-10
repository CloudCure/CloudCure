import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiagnosisVitalsComponent } from './diagnosis-vitals.component';

describe('DiagnosisVitalsComponent', () => {
  let component: DiagnosisVitalsComponent;
  let fixture: ComponentFixture<DiagnosisVitalsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DiagnosisVitalsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DiagnosisVitalsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
