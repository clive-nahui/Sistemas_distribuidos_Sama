import { TestBed } from '@angular/core/testing';

import { CartavariedadesService } from './cartavariedades.service';

describe('CartavariedadesService', () => {
  let service: CartavariedadesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CartavariedadesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
