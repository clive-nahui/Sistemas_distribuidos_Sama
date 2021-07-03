import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductCategoriaComponent } from './product-categoria.component';

describe('ProductCategoriaComponent', () => {
  let component: ProductCategoriaComponent;
  let fixture: ComponentFixture<ProductCategoriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductCategoriaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductCategoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
