import { TestBed } from '@angular/core/testing';

import { Placabaseservice } from './placabaseservice';

describe('Placabaseservice', () => {
  let service: Placabaseservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Placabaseservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
