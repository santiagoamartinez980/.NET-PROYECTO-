import { TestBed } from '@angular/core/testing';

import { Almacenamientoservice } from './almacenamientoservice';

describe('Almacenamientoservice', () => {
  let service: Almacenamientoservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Almacenamientoservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
