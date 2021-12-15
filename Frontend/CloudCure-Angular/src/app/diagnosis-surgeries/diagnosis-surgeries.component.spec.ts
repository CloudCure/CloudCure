import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiagnosisSurgeriesComponent } from './diagnosis-surgeries.component';

describe('DiagnosisSurgeriesComponent', () => {
  let component: DiagnosisSurgeriesComponent;
  let fixture: ComponentFixture<DiagnosisSurgeriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DiagnosisSurgeriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DiagnosisSurgeriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
