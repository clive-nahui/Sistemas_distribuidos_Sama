import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CartavariedadesComponent } from './cartavariedades.component';

describe('CartavariedadesComponent', () => {
  let component: CartavariedadesComponent;
  let fixture: ComponentFixture<CartavariedadesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CartavariedadesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CartavariedadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
