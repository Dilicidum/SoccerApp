import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpHandler, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { retry, catchError, map } from 'rxjs/operators';
import { Router } from '@angular/router';
import {handlerError} from '../helpers/ErrorHandler';
@Injectable({
  providedIn: 'root'
})
export class CheckService {
  baseUrl:string='http://localhost:67011/api/';
  constructor(private http:HttpClient,private router:Router) { }

  checkIsEmailUnique(emailToCheck:string){
    return  this.http.get(this.baseUrl+'emails'+`?email=${emailToCheck}`,).pipe(
      retry(2),
      catchError(handlerError),
      map(response=>{
        return response;
      })
    )
  }

  checkIsUserNameIsUnique(userName:string){
    return this.http.get(this.baseUrl+'Users/UserNameIsUnique?UserName='+userName).pipe(
      retry(2),
      catchError(handlerError),
    )
  }

}
