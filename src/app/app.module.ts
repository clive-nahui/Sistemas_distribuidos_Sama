import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms'; //validar
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './page/home/home.component';
import { CartaComponent } from './page/carta/carta.component';
import { LocalComponent } from './page/local/local.component';
//import { PedidosComponent } from './page/pedidos/pedidos.component';
import { NosotrosComponent } from './page/nosotros/nosotros.component';
import { OrdersComponent } from './page/pedidos/orders.component';
import { UserNewComponent } from './access/user-new/user-new.component';
import { LoginComponent } from './access/login/login.component';
import { PrivadoComponent } from './access/privado/privado.component';
import { RecaptchaModule, RecaptchaFormsModule } from 'ng-recaptcha';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CartaComponent,
    LocalComponent,
//  PedidosComponent,
    NosotrosComponent,
    OrdersComponent,
    UserNewComponent,
    LoginComponent,
    PrivadoComponent,
    
  
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    RecaptchaModule,
    RecaptchaFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
