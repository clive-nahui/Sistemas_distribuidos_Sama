import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-categoria',
  templateUrl: './product-categoria.component.html',
  styleUrls: ['./product-categoria.component.css']
})
export class ProductCategoriaComponent implements OnInit {

  categoriaForm = this.fb.group({

    categoria: ['', Validators.required],
 
    images: this.fb.array([
     this.fb.group({
      nombre:'',
      ruta:''
      })
    ])
  });

  //necesitamos una funcion para leer el arreglo de imagenes

  get imagesGroup(){
 return(<FormArray>(<FormGroup>this.categoriaForm).get('images')).controls;

  }

  constructor(private fb: FormBuilder) { }

onSubmit(){
  if(this.categoriaForm.valid){
    console.log(this.categoriaForm.value);
  }
}

  ngOnInit(): void {
  }

}