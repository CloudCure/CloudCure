import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientIntakePageComponent } from './patient-intake-page.component';

describe('PatientIntakePageComponent', () => {
  let component: PatientIntakePageComponent;
  let fixture: ComponentFixture<PatientIntakePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientIntakePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientIntakePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
