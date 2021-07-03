import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RecaptchaModule, RecaptchaFormsModule } from 'ng-recaptcha';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './access/login/login.component';
import { UserNewComponent } from './access/user-new/user-new.component';
//import { ProjectComponent } from './pages/project/project.component';
//import { ApartmentComponent } from './pages/apartment/apartment.component';
import { CartaComponent } from './pages/carta/carta.component';
import { LocalComponent } from './pages/local/local.component';
import { NosotrosComponent } from './pages/nosotros/nosotros.component';
import { PedidosComponent } from './pages/pedidos/pedidos.component';
import { CartavariedadesComponent } from './pages/cartavariedades/cartavariedades.component';
import { ProductNewComponent } from './access/product/product-new/product-new.component';
import { ProductIndexComponent } from './access/product/product-index/product-index.component';
import { ProductCategoriaComponent } from './access/product/product-categoria/product-categoria.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    UserNewComponent,
//    ProjectComponent,
//    ApartmentComponent,
    CartaComponent,
    LocalComponent,
    NosotrosComponent,
    PedidosComponent,
    CartavariedadesComponent,
    ProductNewComponent,
    ProductIndexComponent,
    ProductCategoriaComponent
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
