import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FinalizedDiagnosisViewComponent } from './finalized-diagnosis-view.component';

describe('FinalizedDiagnosisViewComponent', () => {
  let component: FinalizedDiagnosisViewComponent;
  let fixture: ComponentFixture<FinalizedDiagnosisViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FinalizedDiagnosisViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FinalizedDiagnosisViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
