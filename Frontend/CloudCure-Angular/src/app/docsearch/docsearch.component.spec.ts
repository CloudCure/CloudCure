import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocsearchComponent } from './docsearch.component';

describe('DocsearchComponent', () => {
  let component: DocsearchComponent;
  let fixture: ComponentFixture<DocsearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DocsearchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DocsearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
