import { Component, OnInit } from '@angular/core';
import { CategoriaService } from 'src/app/services/categoria.service';

@Component({
  selector: 'app-carta',
  templateUrl: './carta.component.html',
  styleUrls: ['./carta.component.css']
})
export class CartaComponent implements OnInit {
  categorias = [];

  constructor(private readonly categoriaService: CategoriaService) { }

  getCategorias() {
    this.categoriaService.getCategorias().subscribe((rest: any) => {
      ///console.log(rest.data);
      this.categorias = rest.data;
    })
  }

  ngOnInit(): void {
    this.getCategorias();
  }

}
