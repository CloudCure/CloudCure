import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewMedicationsComponent } from './view-medications.component';

describe('ViewMedicationsComponent', () => {
  let component: ViewMedicationsComponent;
  let fixture: ComponentFixture<ViewMedicationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewMedicationsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewMedicationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
