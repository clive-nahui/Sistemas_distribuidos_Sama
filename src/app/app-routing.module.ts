import { NgModule } from '@angular/core';
import { RouterModule, Routes } from  '@angular/router';
import { LoginComponent } from './access/login/login.component';
import { UserNewComponent } from './access/user-new/user-new.component';
import { HomeComponent } from './pages/home/home.component';
import { CartavariedadesComponent } from './pages/cartavariedades/cartavariedades.component';
import { CartaComponent } from './pages/carta/carta.component';
import { NosotrosComponent } from './pages/nosotros/nosotros.component';
import { PedidosComponent } from './pages/pedidos/pedidos.component';
import { LocalComponent } from './pages/local/local.component';
import { ProductNewComponent } from './access/product/product-new/product-new.component';
import { ProductCategoriaComponent } from './access/product/product-categoria/product-categoria.component';


const routes: Routes = [
    { path: 'home', component: HomeComponent },
    { path: 'login', component: LoginComponent },
    {path:'nosotros',component:NosotrosComponent},
    { path: 'user-new', component: UserNewComponent },
    { path: ':id', component: CartaComponent },
    { path: 'cartavariedades/:id', component: CartavariedadesComponent},
    {path: 'local', component: LocalComponent},
    {path: 'orders', component: PedidosComponent},
    { path: '', redirectTo: 'home', pathMatch: 'full' },

    {path: 'admin/product/new', component: ProductNewComponent},
    {path: 'admin/product/product-categoria', component: ProductCategoriaComponent}

];

@NgModule({
    imports: [ RouterModule.forRoot(routes) ],
    exports: [ RouterModule ]
})
export class AppRoutingModule {}