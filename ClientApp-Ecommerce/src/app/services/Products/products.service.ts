import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  Url = 'https://localhost:44365/';
  Api = 'api/Products/';
  constructor(private http: HttpClient) { }

  getProductos() : Observable<any> {
    return this.http.get<any>(this.Url + this.Api);
  }
}
