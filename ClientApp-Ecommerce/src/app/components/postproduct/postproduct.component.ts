import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-postproduct',
  templateUrl: './postproduct.component.html',
  styleUrls: ['./postproduct.component.css']
})
export class PostproductComponent implements OnInit {
  url : any;
  Id_User : any;
  constructor(private router: Router) {
    this.url = window.location.pathname;
    this.Id_User = this.url.substring(this.url.length-1, this.url.length);

    this.HeaderComponent();
   }

  ngOnInit(): void {
  }

  regresar(){
    this.router.navigate((['/admin/', this.Id_User]))
  }

  //Function validar visibilidad component header
  HeaderComponent() {
    const cont_admin = document.querySelector("#container_admin");
    const cont_cliente = document.querySelector("#container_cliente");

    cont_admin?.classList.remove("disabled");
    cont_cliente?.classList.add("disabled");
  }
}
