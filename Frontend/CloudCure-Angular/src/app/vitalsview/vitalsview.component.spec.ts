import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VitalsviewComponent } from './vitalsview.component';

describe('VitalsviewComponent', () => {
  let component: VitalsviewComponent;
  let fixture: ComponentFixture<VitalsviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VitalsviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VitalsviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
