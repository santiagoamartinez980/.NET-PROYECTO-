import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Procesadorcomponent } from './procesadorcomponent';

describe('Procesadorcomponent', () => {
  let component: Procesadorcomponent;
  let fixture: ComponentFixture<Procesadorcomponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Procesadorcomponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Procesadorcomponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
