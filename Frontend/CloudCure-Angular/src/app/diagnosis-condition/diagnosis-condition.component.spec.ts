import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiagnosisConditionComponent } from './diagnosis-condition.component';

describe('DiagnosisConditionComponent', () => {
  let component: DiagnosisConditionComponent;
  let fixture: ComponentFixture<DiagnosisConditionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DiagnosisConditionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DiagnosisConditionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
