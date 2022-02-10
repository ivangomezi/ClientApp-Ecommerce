import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { EcommerceComponent } from './pages/ecommerce/ecommerce.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { AdministradorComponent } from './pages/administrador/administrador.component';
import { UsuariosComponent } from './pages/usuarios/usuarios.component';
import { TopComponent } from './pages/top/top.component';
import { PostproductComponent } from './components/postproduct/postproduct.component';
import { PutproductComponent } from './components/putproduct/putproduct.component';
import { PostusuariosComponent } from './components/postusuarios/postusuarios.component';
import { CarritoComponent } from './pages/carrito/carrito.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    EcommerceComponent,
    HeaderComponent,
    FooterComponent,
    AdministradorComponent,
    UsuariosComponent,
    TopComponent,
    PostproductComponent,
    PutproductComponent,
    PostusuariosComponent,
    CarritoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    //ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
