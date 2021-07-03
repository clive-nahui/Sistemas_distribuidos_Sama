import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-user-new',
  templateUrl: './user-new.component.html',
  styleUrls: ['./user-new.component.css']
})
export class UserNewComponent implements OnInit {
  usernewForm = this.fb.group({
    LoginUsuario: ['', Validators.required, Validators.email],
    PasswordUsuario: ['', Validators.required, Validators.email],
    IdPerfil: ['', Validators.required, Validators.email],
    Nombres: ['', Validators.required, Validators.email],
    ApellidoPaterno: ['', Validators.required, Validators.email],
    ApellidoMaterno: ['', Validators.required, Validators.email],
    DocumentoIdentidad: ['', Validators.required, Validators.email],
    
  })

  constructor(private fb: FormBuilder) { }
  onSubmit(){
    if(this.usernewForm.valid) {
        console.log(this.usernewForm.value)
      } else {
        alert("Formulario no valido");
      }
    }
  ngOnInit(): void {
  }

}
