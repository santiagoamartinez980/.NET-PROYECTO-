import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Almacenamientocomponent } from './almacenamientocomponent';

describe('Almacenamientocomponent', () => {
  let component: Almacenamientocomponent;
  let fixture: ComponentFixture<Almacenamientocomponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Almacenamientocomponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Almacenamientocomponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
