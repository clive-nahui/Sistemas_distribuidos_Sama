import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductCategoriaService {

  constructor(private readonly http: HttpClient) { }
  getProductos(idCategoria) {
    return this.http.get('https://localhost:44309/api/producto/getproductos?IDCATEGORIA=' + idCategoria);
  }
}
