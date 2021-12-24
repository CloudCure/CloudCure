import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSurgeriesComponent } from './view-surgeries.component';

describe('ViewSurgeriesComponent', () => {
  let component: ViewSurgeriesComponent;
  let fixture: ComponentFixture<ViewSurgeriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewSurgeriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewSurgeriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
