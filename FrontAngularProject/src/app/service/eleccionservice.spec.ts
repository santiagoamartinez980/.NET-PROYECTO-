import { TestBed } from '@angular/core/testing';

import { Eleccionservice } from './eleccionservice';

describe('Eleccionservice', () => {
  let service: Eleccionservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Eleccionservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
