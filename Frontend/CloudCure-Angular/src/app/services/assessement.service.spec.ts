import { TestBed } from '@angular/core/testing';

import { AssessementService } from './assessement.service';

describe('AssessementService', () => {
  let service: AssessementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AssessementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
