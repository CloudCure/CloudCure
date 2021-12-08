import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyClickerComponent } from './body-clicker.component';

describe('BodyClickerComponent', () => {
  let component: BodyClickerComponent;
  let fixture: ComponentFixture<BodyClickerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BodyClickerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BodyClickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
