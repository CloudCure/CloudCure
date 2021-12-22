import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewConditionsComponent } from './view-conditions.component';

describe('ViewConditionsComponent', () => {
  let component: ViewConditionsComponent;
  let fixture: ComponentFixture<ViewConditionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewConditionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewConditionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
