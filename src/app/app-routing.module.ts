import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { CartaComponent } from './page/carta/carta.component';


import { HomeComponent } from './page/home/home.component';
import { PedidosComponent } from './page/pedidos/pedidos.component';
import { LocalComponent } from './page/local/local.component';
import { NosotrosComponent } from './page/nosotros/nosotros.component';



const routes: Routes =[
    {path: 'home', component: HomeComponent},
    {path:'nosotros',component:NosotrosComponent},
    {path: 'carta', component: CartaComponent},
    {path: 'local', component: LocalComponent},
    {path: 'pedidos', component: PedidosComponent},
    
    {path: '', redirectTo: 'home', pathMatch: 'full'}
    
];

@NgModule({

    imports:[RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {}