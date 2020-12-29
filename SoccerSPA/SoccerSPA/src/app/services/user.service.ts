import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { user } from '../models/user';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl:string  = 'http://localhost:61711/api/Users/';

  constructor(private http:HttpClient) { }

  getUsersAvatars():Observable<any>{
    return this.http.get('');
  }

  getUserInfo():Observable<user>{
    return this.http.get<user>(this.baseUrl+localStorage.getItem('userId'))
  }

}
