import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { game } from '../models/game';
import { player } from '../models/player';

@Injectable({
  providedIn: 'root'
})
export class GamesService {
  baseUrl:string='http://localhost:61711/api/Games';
  constructor(private http:HttpClient) { }

  getAllGames():Observable<game[]>{
    return this.http.get<game[]>(this.baseUrl);
  }

  getSortedGamesByDate():Observable<game[]>{
    return this.http.get<game[]>(this.baseUrl + '/DateSorted')
  }

  getSortedGamesByResult():Observable<game[]>{
    return this.http.get<game[]>(this.baseUrl + '/ResultSorted')
  }

}
