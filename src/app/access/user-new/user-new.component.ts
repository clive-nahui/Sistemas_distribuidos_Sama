import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserNewService } from 'src/app/services/user-new.service';

@Component({
  selector: 'app-user-new',
  templateUrl: './user-new.component.html',
  styleUrls: ['./user-new.component.css']
})
export class UserNewComponent implements OnInit {

  usernewForm = this.fb.group({
    Email: ['', Validators.required],
    PasswordUsuario: ['', Validators.required],
    Nombres: ['', Validators.required],
    ApellidoPaterno: ['', Validators.required],
    ApellidoMaterno: ['', Validators.required],
    DocumentoIdentidad: ['', Validators.required]
  })

  constructor(private fb: FormBuilder, private readonly userService: UserNewService, private router: Router) { }

  insert(data) {
    const header = {};

    this.userService.insert(data, header).subscribe((rest: any) => {
      if(rest.isSuccess) {
        alert("Usuario creado con ID: " + rest.data.id + " y Nombre: " + rest.data.nombre );
        this.router.navigate(['login']);
      } else {
        alert(rest.errorMessage);
      }
    })
  }

  onSubmit(){
    if(this.usernewForm.valid) {
      console.log(this.usernewForm.value);
      this.insert(this.usernewForm.value);
    } else {
      alert("Formulario no valido");
    }
    }
  ngOnInit(): void {
  }

}
