import { TestBed } from '@angular/core/testing';

import { ProductCategoriaService } from './product-categoria.service';

describe('ProductCategoriaService', () => {
  let service: ProductCategoriaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductCategoriaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
