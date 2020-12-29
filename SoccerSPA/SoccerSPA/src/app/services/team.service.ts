import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { game } from '../models/game';
import { team } from '../models/team';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  baseUrl:string='http://localhost:61711/api/Teams';
  constructor(private httpClient:HttpClient) { }

  getGameByDate(homeTeamId:number,date:Date):Observable<game[]>{
    return this.httpClient.get<game[]>(this.baseUrl+'/'+homeTeamId+'/'+'Date');
  }


}
