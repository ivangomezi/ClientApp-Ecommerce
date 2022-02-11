import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Products } from 'src/app/models/Products';
import { ProductsService } from 'src/app/services/Products/products.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-putproduct',
  templateUrl: './putproduct.component.html',
  styleUrls: ['./putproduct.component.css']
})
export class PutproductComponent implements OnInit {
  Id_product: any;
  form!: FormGroup;
  constructor(
    private router: Router,
    private fb:FormBuilder,
    private api: ProductsService,
    private ruta : ActivatedRoute
    ) { 

    this.Id_product = ruta.snapshot.paramMap.get('id');

    this.HeaderComponent();

    this.form = this.fb.group({
      code: ['', Validators.required],
      name: ['', Validators.required],
      descrip: ['', Validators.required],
      price: ['', Validators.required],
      imagen: ['', Validators.required]
    });

    //ejecular consulta productos id
    this.api.getProductosID(this.Id_product).subscribe({
      next: data => {
        this.form.get('code')?.setValue(data.cod_Product);
        this.form.get('name')?.setValue(data.name_Product);
        this.form.get('descrip')?.setValue(data.desc_Product);
        this.form.get('price')?.setValue(data.price_Product);
        this.form.get('imagen')?.setValue(data.img_Product);
      },
      error: error => {
        console.error(error.error)
      }
    });
  }

  ngOnInit(): void {
  }

  register(){
    if(this.form.status != "INVALID") {
      
      const body : Products = {
        Id_Product : Number(this.Id_product),
        Cod_Product : this.form.get('code')?.value,
        Name_Product : this.form.get('name')?.value,
        Desc_Product : this.form.get('descrip')?.value,
        Price_Product : Number(this.form.get('price')?.value),
        Img_Product : this.form.get('imagen')?.value
      }

      console.log(body)

      //actualizar
      this.api.putProductos(body).subscribe({
        next: data => {
          this.router.navigate((['/admin/', localStorage.getItem("id_user")]))
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
    this.router.navigate((['/admin/', localStorage.getItem("id_user")]))
  }

  //Function validar visibilidad component header
  HeaderComponent() {
    const cont_admin = document.querySelector("#container_admin");
    const cont_cliente = document.querySelector("#container_cliente");

    cont_admin?.classList.remove("disabled");
    cont_cliente?.classList.add("disabled");
  }

}
