import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ProductCategoriaService } from 'src/app/services/product-categoria.service';

@Component({
  selector: 'app-cartavariedades',
  templateUrl: './cartavariedades.component.html',
  styleUrls: ['./cartavariedades.component.css']
})
export class CartavariedadesComponent implements OnInit {

  productos = [];

    constructor(private readonly productoService: ProductCategoriaService,
      private activeRoute: ActivatedRoute) { }

    getProductos(idCategoria:number) {
      this.productoService.getProductos(idCategoria).subscribe((rest: any) => {
        ///console.log(rest.data);
        this.productos = rest.data;
      })
    }
  
    ngOnInit(): void {
      this.activeRoute.params.subscribe((params: Params) => {
        if(params.id) {
          this.getProductos(params.id);
        }
      })


      
    }
}