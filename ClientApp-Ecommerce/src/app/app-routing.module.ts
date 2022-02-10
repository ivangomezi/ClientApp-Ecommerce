import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PostproductComponent } from './components/postproduct/postproduct.component';
import { PostusuariosComponent } from './components/postusuarios/postusuarios.component';
import { PutproductComponent } from './components/putproduct/putproduct.component';
import { AdministradorComponent } from './pages/administrador/administrador.component';
import { CarritoComponent } from './pages/carrito/carrito.component';
import { EcommerceComponent } from './pages/ecommerce/ecommerce.component';
import { LoginComponent } from './pages/login/login.component';
import { TopComponent } from './pages/top/top.component';
import { UsuariosComponent } from './pages/usuarios/usuarios.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },

  { path: 'cliente/:id', component: EcommerceComponent },
  { path: 'cliente/carro/:id', component: CarritoComponent },

  { path: "admin/:id", component: AdministradorComponent },
  { path: "admin/post/:id", component: PostproductComponent},
  { path: "admin/put/:id", component: PutproductComponent},
  { path: "admin/post/user/:id", component: PostusuariosComponent},
  { path: "admin/usuarios/:id", component: UsuariosComponent},
  { path: "admin/top/:id", component: TopComponent},

  { path: '**', pathMatch: 'full', redirectTo: 'login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
