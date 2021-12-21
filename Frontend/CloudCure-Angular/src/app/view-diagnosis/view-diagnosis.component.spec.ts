import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewDiagnosisComponent } from './view-diagnosis.component';

describe('ViewDiagnosisComponent', () => {
  let component: ViewDiagnosisComponent;
  let fixture: ComponentFixture<ViewDiagnosisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewDiagnosisComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewDiagnosisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
