import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { first } from 'rxjs/operators';
import { game } from '../models/game';
import { player } from '../models/player';

@Injectable({
  providedIn: 'root'
})
export class PlayersService {
  baseUrl:string='http://localhost:61711/api/Players';
  constructor(private http:HttpClient) { }

  getAllPlayers():Observable<player[]>{
    return this.http.get<player[]>(this.baseUrl)
  }

  getPlayerById(playerId:number):Observable<player>{
    return this.http.get(this.baseUrl +'/'+ playerId)
  }

  getPlayersByFirstName(firstName:string):Observable<player[]>{
    return this.http.get<player[]>(this.baseUrl+'?FirstName='+firstName);
  }

  getPlayersByLastName(lastName:string):Observable<player[]>{
    return this.http.get<player[]>(this.baseUrl+'?LastName='+lastName);
  }

}
