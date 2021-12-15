import { TestBed } from '@angular/core/testing';

import { VitalsService } from './vitals.service';

describe('VitalsService', () => {
  let service: VitalsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VitalsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
