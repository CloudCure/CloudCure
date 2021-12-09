import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AngularModelsComponent } from './angular-models.component';

describe('AngularModelsComponent', () => {
  let component: AngularModelsComponent;
  let fixture: ComponentFixture<AngularModelsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AngularModelsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AngularModelsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
