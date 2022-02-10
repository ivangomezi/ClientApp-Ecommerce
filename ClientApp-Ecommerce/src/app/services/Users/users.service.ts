import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Users } from 'src/app/models/Users';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  Url = 'https://localhost:44365/';
  Api = 'api/Users/';

  constructor(private http: HttpClient) { }

  getUsers(): Observable<any> {
    return this.http.get(this.Url + this.Api);
  }

  getUsersLogin(User_Name : any, Password : any): Observable<any> {
    return this.http.get<Users>(this.Url + this.Api + User_Name + "/" + Password);
  }

  postUsers(body: Users): Observable<Users>{
    return this.http.post<Users>(this.Url + this.Api, body);
  }
}
