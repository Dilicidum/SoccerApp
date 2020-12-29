import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { changePasswordModel } from '../models/changePasswordModel';
import { map } from 'rxjs/operators';
import { user } from '../models/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MineService {

  baseUrl:string  = 'http://localhost:61711/api/Mine/';

  constructor(private http:HttpClient) { }

  changePassword(changePasswordModel:changePasswordModel){
    return this.http.put(this.baseUrl+'Password',changePasswordModel).pipe(
      map(res=>{
        return res;
      })
    )
  }

  changeUserInfo(user:user){
    return this.http.put(this.baseUrl+'Settings',user).pipe(
      map(res=>{
        console.log('res = ',res);
        return res;
      })
    );
  }

  getCurrentUserInfo():Observable<user>{
    return this.http.get(this.baseUrl);
  }


}
