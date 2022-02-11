import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductsService } from 'src/app/services/Products/products.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-administrador',
  templateUrl: './administrador.component.html',
  styleUrls: ['./administrador.component.css']
})
export class AdministradorComponent implements OnInit {
  url : any;
  Id_User : any;
  listaProduct: any[] = [];
  constructor(private router: Router,
    private api: ProductsService) {

    this.HeaderComponent();

    this.url = window.location.pathname;
    this.Id_User = this.url.substring(this.url.length-1, this.url.length);

    //ejecular consulta productos
    this.api.getProductos().subscribe({
      next: data => {
        this.listaProduct = data
      },
      error: error => {
        console.error(error.error)
      }
    });
  }

  ngOnInit(): void {
  }

  nuevo() {
    this.router.navigate((['/admin/post/', this.Id_User]))
  }
  actualizar(e:any) {
    this.router.navigate((['/admin/put/', e.target.id]))
    localStorage.setItem("id_user", this.Id_User)
  }
  eliminar(e:any) {
    Swal.fire(
      {
        title: 'Eliminando producto',
        text: '¿Seguro que desea eliminar el producto?',
        icon: 'warning',
        showDenyButton: true,
        denyButtonText: "No eliminar"
      }
    ).then ((result)=> {
      if (result['isConfirmed']){
        //api delete producto
        this.api.deleteProductos(e.target.id).subscribe({
          next: data => {
            window.location.reload();
          },
          error: error => {
            console.error(error.status);
          }
        });
      }
    });
  }

  //Function validar visibilidad component header
  HeaderComponent() {
    const cont_admin = document.querySelector("#container_admin");
    const cont_cliente = document.querySelector("#container_cliente");

    cont_admin?.classList.remove("disabled");
    cont_cliente?.classList.add("disabled");
  }
}
