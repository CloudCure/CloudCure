import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListDoctorComponent } from './list-doctor.component';

describe('ListDoctorComponent', () => {
  let component: ListDoctorComponent;
  let fixture: ComponentFixture<ListDoctorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListDoctorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListDoctorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
