import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { CartaComponent } from './page/carta/carta.component';
import { LoginComponent } from './access/login/login.component';
import { UserNewComponent } from './access/user-new/user-new.component';

import { HomeComponent } from './page/home/home.component';
//import { PedidosComponent } from './page/pedidos/pedidos.component';
import { OrdersComponent } from './page/pedidos/orders.component';
import { LocalComponent } from './page/local/local.component';
import { NosotrosComponent } from './page/nosotros/nosotros.component';



const routes: Routes =[
    {path: 'home', component: HomeComponent},
    {path:'nosotros',component:NosotrosComponent},
    {path: 'carta', component: CartaComponent},
    {path: 'local', component: LocalComponent},
    //{path: 'pedidos', component: PedidosComponent},
    { path: 'login', component: LoginComponent },
    { path: 'user-new', component: UserNewComponent },
    {path: 'orders', component: OrdersComponent},
    
    {path: '', redirectTo: 'home', pathMatch: 'full'}
    
];

@NgModule({

    imports:[RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {}