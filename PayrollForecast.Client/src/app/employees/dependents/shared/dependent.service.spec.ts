import { TestBed } from '@angular/core/testing';

import { DependentService } from './dependent.service';

describe('DependentService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DependentService = TestBed.get(DependentService);
    expect(service).toBeTruthy();
  });
});
