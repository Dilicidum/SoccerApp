import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';
import { userLoginModel } from '../models/userLoginModel';
import { retry, catchError, map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { userResponse } from '../models/userResponse';
//import { forgetPasswordModel } from '../models/forgetPasswordModel';
import { Router } from '@angular/router';
//import { resetPasswordModel } from '../models/resetPasswordModel';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  baseUrl:string='http://localhost:61711/api/login';
  constructor(private http:HttpClient,
    private authService:AuthenticationService,private router:Router) { }

  logIn(userLoginModel:userLoginModel):Observable<userResponse>{
    return this.http.post<userResponse>(this.baseUrl,userLoginModel).pipe(
      retry(2),
      catchError(this.authService.handleError),
      map(response=>{

        this.authService.setUser(response);
        return response;
      })
    )
  }





}
