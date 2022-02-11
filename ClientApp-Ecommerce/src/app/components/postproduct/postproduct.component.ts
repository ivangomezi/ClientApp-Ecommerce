import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Products } from 'src/app/models/Products';
import { ProductsService } from 'src/app/services/Products/products.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-postproduct',
  templateUrl: './postproduct.component.html',
  styleUrls: ['./postproduct.component.css']
})
export class PostproductComponent implements OnInit {
  url : any;
  Id_User : any;
  form!: FormGroup;
  constructor(
    private router: Router,
    private fb:FormBuilder,
    private api: ProductsService
  ) {
    this.url = window.location.pathname;
    this.Id_User = this.url.substring(this.url.length-1, this.url.length);

    this.HeaderComponent();

    this.form = this.fb.group({
      code: ['', Validators.required],
      name: ['', Validators.required],
      descrip: ['', Validators.required],
      price: ['', Validators.required],
      imagen: ['', Validators.required]
    });
   }

  ngOnInit(): void {
  }

  register(){
    if(this.form.status != "INVALID") {
      
      const body : Products = {
        Id_Product : 0,
        Cod_Product : this.form.get('code')?.value,
        Name_Product : this.form.get('name')?.value,
        Desc_Product : this.form.get('descrip')?.value,
        Price_Product : Number(this.form.get('price')?.value),
        Img_Product : this.form.get('imagen')?.value
      }

      console.log(body)

      //registrar
      this.api.postProductos(body).subscribe({
        next: data => {
          this.router.navigate((['/admin/', this.Id_User]))
          //location.href = '/admin/' + this.Id_User;
        },
        error: error => {
          console.error(error.status);
        }
      });
    }
    else {
      Swal.fire(
        {
          title: 'Campos vacios',
          text: 'Complete todos los campos para registrar.',
          icon: 'warning'
        }
      )
    }
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
