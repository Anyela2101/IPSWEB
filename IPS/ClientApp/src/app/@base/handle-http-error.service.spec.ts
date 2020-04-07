import { TestBed } from '@angular/core/testing';

import { HandleHttpErrorService } from './handle-http-error.service';

describe('HandleHttpErrorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HandleHttpErrorService = TestBed.get(HandleHttpErrorService);
    expect(service).toBeTruthy();
  });
});
