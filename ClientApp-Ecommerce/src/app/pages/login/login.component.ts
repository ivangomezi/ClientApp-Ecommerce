import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsersService } from 'src/app/services/Users/users.service';
//import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  constructor(
    private router: Router,
    private fb:FormBuilder,
    private api: UsersService
  ) { 

    this.form = this.fb.group({
      User: ['', Validators.required],
      Password: ['', Validators.required]
    });
  }

  ngOnInit(): void {
  }

  Init(){
    if(this.form.status != "INVALID") {
      
      //Login
      this.api.getUsersLogin(this.form.get('User')?.value, this.form.get('Password')?.value).subscribe({
        next: data => {
          if (data.id_User > 0){
            if (data.id_Rol == 1) {
              this.router.navigate((['/admin/', data.id_User]))
            }
            else {
              this.router.navigate((['/cliente/', data.id_User]))
            }
          }
          else {
            Swal.fire(
              {
                title: 'Datos no encontrados',
                text: 'Los datos de Usuario y Contraseña no se encuentran registrados.',
                icon: 'warning'
              }
            )
          }
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
          text: 'Complete los campos Usuario y Contraseña.',
          icon: 'warning'
        }
      )
    }
  }

}
