import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Buys } from 'src/app/models/Buys';

@Injectable({
  providedIn: 'root'
})
export class BuysService {
  Url = 'https://localhost:44365/';
  Api = 'api/Buys/';
  constructor(private http: HttpClient) { }

  postBuys(body : Buys) : Observable<any> {
    return this.http.post<any>(this.Url + this.Api, body);
  }
}
