import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';
import { userResponse } from '../models/userResponse';
import { userRegistrationModel } from '../models/userRegistrationModel';
import { retry, catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  baseUrl:string='http://localhost:61711/api/';
  constructor(private http:HttpClient,private authService:AuthenticationService) { }

  register(userRegistrationModel:userRegistrationModel):Observable<userResponse>{
    return this.http.post<userResponse>(this.baseUrl+'Registration',userRegistrationModel).pipe(
      retry(2),
      catchError(this.authService.handleError),
      map(response=>{
        this.authService.setUser(response);
        return response;
      })
    )
  }
}
