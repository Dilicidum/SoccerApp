import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { stadium } from '../models/stadium';

@Injectable({
  providedIn: 'root'
})
export class StadiumService {
  baseUrl:string='http://localhost:61711/api/Stadiums';
  constructor(private http:HttpClient) { }

  getStadiumById(stadiumId:number):Observable<stadium>{
    return this.http.get(this.baseUrl + '/' + stadiumId);
  }
}
