import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Products } from 'src/app/models/Products';

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
  getProductosID(id : any) : Observable<any> {
    return this.http.get<any>(this.Url + this.Api + id);
  }
  deleteProductos(id : any) : Observable<any> {
    return this.http.delete<any>(this.Url + this.Api + id);
  }
  postProductos(body: Products): Observable<Products>{
    return this.http.post<Products>(this.Url + this.Api, body);
  }
  putProductos(body: Products): Observable<Products>{
    return this.http.put<Products>(this.Url + this.Api, body);
  }
}
