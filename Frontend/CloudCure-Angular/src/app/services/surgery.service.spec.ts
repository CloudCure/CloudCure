import { TestBed } from '@angular/core/testing';

import { SurgeryService } from './surgery.service';

describe('SurgeryService', () => {
  let service: SurgeryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SurgeryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
