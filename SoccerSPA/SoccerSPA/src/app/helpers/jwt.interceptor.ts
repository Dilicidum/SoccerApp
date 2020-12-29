import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { AuthenticationService } from '../services/authentication.service';
import { Injectable } from '@angular/core';

@Injectable()
export class JwtInterceptor implements HttpInterceptor{
  constructor(private authService:AuthenticationService){}

  intercept(req:HttpRequest<any>,next:HttpHandler){

    if(this.authService.isLoggedIn()){
      let token = localStorage.getItem('token');
      console.log('token = ',token);

      req = req.clone({
        setHeaders:{
          Authorization:`Bearer ${token}`
        }
      })
    }
    return next.handle(req);
  }
}
