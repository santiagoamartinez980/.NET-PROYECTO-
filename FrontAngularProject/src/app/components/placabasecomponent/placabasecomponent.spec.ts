import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Placabasecomponent } from './placabasecomponent';

describe('Placabasecomponent', () => {
  let component: Placabasecomponent;
  let fixture: ComponentFixture<Placabasecomponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Placabasecomponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Placabasecomponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
