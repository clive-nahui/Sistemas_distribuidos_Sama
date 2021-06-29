import { Component, OnInit } from '@angular/core';
import { FormBuilder,  Validators } from '@angular/forms';
import { RecaptchaErrorParameters } from 'ng-recaptcha';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public resolved(captchaResponse: string): void {
    console.log(`Resolved captcha with response: ${captchaResponse}`);
    // Bienvenido humano
  }

  public onError(errorDetails: RecaptchaErrorParameters): void {
    console.log(`reCAPTCHA error encountered; details:`, errorDetails);
    // No eres humano
  }

  loginForm = this.fb.group ({
    email: ['', Validators.required, Validators.email],
    password: ['', Validators.required],
    
	})
  
  constructor(private fb: FormBuilder) {
 
  }
  
  onSubmit(){
    if(this.loginForm.valid){
      console.log(this.loginForm.value);
    } else {
        alert("Formulario no valido");
      }
    }
  ngOnInit(): void {
  }

}
