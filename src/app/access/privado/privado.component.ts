import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
@Component({
  selector: 'app-privado',
  templateUrl: './privado.component.html',
  styleUrls: ['./privado.component.css']
})
export class PrivadoComponent implements OnInit {

  privadoForm = this.fb.group ({
    login: ['', Validators.required, Validators.email],
    password: ['', Validators.required]
	})


  constructor(private fb: FormBuilder) { }

onSubmit(){
  if(this.privadoForm.valid){
    console.log(this.privadoForm.value);
  } else {
      alert("Formulario no valido");
    }
  }
  
  ngOnInit(): void {
  }

}
