import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAssessmentsComponent } from './view-assessments.component';

describe('ViewAssessmentsComponent', () => {
  let component: ViewAssessmentsComponent;
  let fixture: ComponentFixture<ViewAssessmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewAssessmentsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewAssessmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
