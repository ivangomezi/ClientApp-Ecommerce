import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  url : any;
  Id_User : any;
  constructor(private router: Router) {
    this.url = window.location.pathname;
    this.Id_User = this.url.substring(this.url.length-1, this.url.length);

    this.HeaderComponent();
   }

  ngOnInit(): void {
  }

  //admin
  producto() {
    this.router.navigate((['/admin/', this.Id_User]))
  }
  usuarios() {
    this.router.navigate((['/admin/usuarios/', this.Id_User]))
  }
  top() {
    this.router.navigate((['/admin/top/', this.Id_User]))
  }

  //cliente
  client() {
    this.router.navigate((['/cliente/', this.Id_User]))
  }
  carro() {
    this.router.navigate((['/cliente/carro/', this.Id_User]))
  }


  //Function validar visibilidad component header
  HeaderComponent() {
    const cont_admin = document.querySelector("#container_admin");
    const cont_cliente = document.querySelector("#container_cliente");

    cont_admin?.classList.remove("disabled");
    cont_cliente?.classList.add("disabled");
  }

}
