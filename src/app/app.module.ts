import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './page/home/home.component';
import { CartaComponent } from './page/carta/carta.component';
import { LocalComponent } from './page/local/local.component';
import { PedidosComponent } from './page/pedidos/pedidos.component';
import { NosotrosComponent } from './page/nosotros/nosotros.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CartaComponent,
    LocalComponent,
    PedidosComponent,
    NosotrosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
