import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-new',
  templateUrl: './product-new.component.html',
  styleUrls: ['./product-new.component.css']
})
export class ProductNewComponent implements OnInit {


  productForm = this.fb.group({


    categoria: ['', Validators.required],
    nombre: ['', Validators.required],
    precio: ['', Validators.required],
    descripcion: ['', Validators.required],

    images: this.fb.array([
     this.fb.group({
      nombre:'',
      ruta:'',
      })
    ])
  });

  //necesitamos una funcion para leer el arreglo de imagenes

  get imagesGroup(){
 return(<FormArray>(<FormGroup>this.productForm).get('images')).controls;

  }

  constructor(private fb: FormBuilder) { }

onSubmit(){
  if(this.productForm.valid){
    console.log(this.productForm.value);
  }
}

  ngOnInit(): void {
  }

}
