import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { userLoginModel } from '../models/userLoginModel';
import {map, retry, catchError} from 'rxjs/operators';
import { Observable, throwError, BehaviorSubject } from 'rxjs';
import { user } from '../models/user';
import { userRegistrationModel } from '../models/userRegistrationModel';
import { userResponse } from '../models/userResponse';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {

  baseUrl:string='http://localhost:61711/api/';
  private currentUserSubject :  BehaviorSubject<userResponse>;
  public currentUser : Observable<userResponse>
  constructor(private http:HttpClient,private router:Router) {
    this.currentUserSubject = new BehaviorSubject<userResponse>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
   }


  public get currentUserValue():userResponse{
    return this.currentUserSubject.value;
  }

  setUser(userResponse:userResponse){
    this.currentUserSubject.next(userResponse);
    localStorage.setItem('token',userResponse.token);
    localStorage.setItem('userId',userResponse.userId);
    console.log('userResponse = ',userResponse);
    let dateTimeTokenExpired = new Date(userResponse.timeTokenExpired);
    let timeTokenExpired = dateTimeTokenExpired.toDateString();
    localStorage.setItem('timeTokenExpired',timeTokenExpired);
  }

  isLoggedIn(){
    let token = localStorage.getItem('token')

    let timeTokenExpired = new Date(localStorage.getItem('timeTokenExpired'));


    let currentTime = new Date();

    if(timeTokenExpired <= currentTime){
      localStorage.removeItem('token');
    }

    if(token){

      return true;
    }else{

      return false
    }

  }

  logOut(){
    localStorage.clear();
    this.currentUserSubject.next(null);
    this.router.navigateByUrl('/login');
  }

  handleError(error:HttpErrorResponse){
    if(error.error instanceof ErrorEvent){
      console.log('Error happened on the client-side',error.error.message);
    }
    else{
      console.log('Error happened on the server side',error.status);
      console.log('Body of error:',error.error);
    }
    return throwError("Something bad happened");
  }
}
