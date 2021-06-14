import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-user-new',
  templateUrl: './user-new.component.html',
  styleUrls: ['./user-new.component.css']
})
export class UserNewComponent implements OnInit {
  usernewForm = this.fb.group({
    email: ['', Validators.required, Validators.email],
    firstname: ['', Validators.required],
    lastname: ['', Validators.required],
    perfil: ['', Validators.required]
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
