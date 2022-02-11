import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Buys } from 'src/app/models/Buys';
import { BuysService } from 'src/app/services/Buys/buys.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.component.html',
  styleUrls: ['./carrito.component.css']
})
export class CarritoComponent implements OnInit {

  url : any;
  Id_User : any;
  total !: any;
  code !: any;

  dataSession : any;
  ListaCompras : any[] = [];

  constructor(
    private router: Router,
    private fb:FormBuilder,
    private api: BuysService
  ) {
    this.url = window.location.pathname;
    this.Id_User = this.url.substring(this.url.length-1, this.url.length);

    this.HeaderComponent();
    this.cargarCompars();
   }

  ngOnInit(): void {
  }

  comprar() {
    const body : Buys = {
      Id_User: Number(localStorage.getItem("id_User")),
      Id_Product : Number(localStorage.getItem("id_Product")),
      Quantity : Number(localStorage.getItem("quantity")),
      Total_Buy : Number(localStorage.getItem("total_Buy")),
      Code_Buy : localStorage.getItem("code_Buy")?.toString()
    }
    this.api.postBuys(body).subscribe({
      next: data => {
        this.router.navigate((['/cliente/', this.Id_User]))
        sessionStorage.clear();
        localStorage.clear();
        Swal.fire(
          {
            position: 'center',
            icon: 'success',
            title: 'Transacción de compra completa.',
            showConfirmButton: false,
            timer: 1500
          }
        )
      },
      error: error => {
        console.error(error.status);
      }
    });
  }

  cargarCompars() {
    this.dataSession = sessionStorage.getItem(this.Id_User);
    this.ListaCompras.push(JSON.parse(this.dataSession))
    console.log(this.ListaCompras);

    this.code = localStorage.getItem("code_Buy")
    this.total = localStorage.getItem("total_Buy")
  }

  regresar(){
    this.router.navigate((['/cliente/', this.Id_User]))
  }
  

  //Function validar visibilidad component header
  HeaderComponent() {
    const cont_admin = document.querySelector("#container_admin");
    const cont_cliente = document.querySelector("#container_cliente");

    cont_admin?.classList.add("disabled");
    cont_cliente?.classList.remove("disabled");
  }

  

}
