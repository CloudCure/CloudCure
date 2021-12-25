import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAllergiesComponent } from './view-allergies.component';

describe('ViewAllergiesComponent', () => {
  let component: ViewAllergiesComponent;
  let fixture: ComponentFixture<ViewAllergiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewAllergiesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewAllergiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
