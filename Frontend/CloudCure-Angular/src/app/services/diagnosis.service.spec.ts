import { TestBed } from '@angular/core/testing';

import { DiagnosisService } from './diagnosis.service';

describe('DiagnosisService', () => {
  let service: DiagnosisService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DiagnosisService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
