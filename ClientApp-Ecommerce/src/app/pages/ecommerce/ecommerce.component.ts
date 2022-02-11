import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductsService } from 'src/app/services/Products/products.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-ecommerce',
  templateUrl: './ecommerce.component.html',
  styleUrls: ['./ecommerce.component.css']
})
export class EcommerceComponent implements OnInit {
  listaProduct: any[] = [];
  total_product: any;
  url : any;
  Id_User : any;
  
  constructor(
    private api: ProductsService,
    private router: Router
  ) { 
    this.url = window.location.pathname;
    this.Id_User = this.url.substring(this.url.length-1, this.url.length);

    this.HeaderComponent();

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

  agregar(e : any) {
    this.api.getProductosID(e.target.id).subscribe({
      next: data => {
        
        this.total_product = Number(data.price_Product) * Number((<HTMLInputElement>document.getElementById("input_"+e.target.id)).value);
        
        var producto = {
            id_User: this.Id_User,
            id_Product: data.id_Product,
            quantity: (<HTMLInputElement>document.getElementById("input_"+e.target.id)).value,
            total_Buy: this.total_product,
            code_Buy: this.randomString(12),
            name_Product: data.name_Product,
            price_Product: data.price_Product,
            img_Product: data.img_Product
        };

        sessionStorage.setItem(this.Id_User, JSON.stringify(producto));
        localStorage.setItem("code_Buy", this.randomString(12))
        localStorage.setItem("total_Buy", this.total_product)
        localStorage.setItem("id_User", this.Id_User)
        localStorage.setItem("id_Product", data.id_Product)
        localStorage.setItem("quantity", (<HTMLInputElement>document.getElementById("input_"+e.target.id)).value)

        Swal.fire(
          {
            position: 'top-end',
            icon: 'success',
            title: 'Agregado a la bolsa.',
            showConfirmButton: false,
            timer: 1500
          }
        )      
      },
      error: error => {
        console.error(error.error)
      }
    });
  }

  //Cadena aleatoria
  randomString(length : any) {
    let chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    var result = '';
    for (var i = length; i > 0; --i) result += chars[Math.floor(Math.random() * chars.length)];
    return result;
  }

  soloNumeros(e:any){
    var code = (e.which) ? e.which : e.keyCode;
    
    if(code==8) {
      return true;
    } else if(code>=48 && code<=57) {
      return true;
    } else{
      return false;
    }
  }

  
  //Function validar visibilidad component header
  HeaderComponent() {
    const cont_admin = document.querySelector("#container_admin");
    const cont_cliente = document.querySelector("#container_cliente");

    cont_admin?.classList.add("disabled");
    cont_cliente?.classList.remove("disabled");
  }
}
