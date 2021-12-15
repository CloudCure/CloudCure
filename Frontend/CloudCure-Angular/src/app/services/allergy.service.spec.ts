import { TestBed } from '@angular/core/testing';

import { AllergyService } from './allergy.service';

describe('AllergyService', () => {
  let service: AllergyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AllergyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
