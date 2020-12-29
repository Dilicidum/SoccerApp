import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { game } from '../models/game';
import { gameUploadModel } from '../models/gameUploadModel';
import { patchModel } from '../models/patchModel';
import { player } from '../models/player';
import { playerUploadModel } from '../models/playerUploadModel';
import { stadium } from '../models/stadium';
import { team } from '../models/team';

@Injectable({
  providedIn: 'root'
})
export class UploadService {
 baseURL:string = 'http://localhost:61711/api/';
  constructor(private http:HttpClient) { }

  headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  }

  uploadPlayer(player:playerUploadModel):Observable<player>{
    return this.http.post<player>(this.baseURL + 'Players',player);
  }

  uploadTeam(team:team):Observable<team>{
    console.log('TEAM = ',team);
    return this.http.post(this.baseURL + "Teams",team);
  }

  uploadStadium(stadium:stadium):Observable<stadium>{
    return this.http.post(this.baseURL + 'Stadiums',stadium);
  }

  uploadGame(game:gameUploadModel):Observable<game>{
    return this.http.post<game>(this.baseURL + 'Games',game);
  }

  changePlayer(playerId:number,patches:patchModel[]){
    return this.http.patch(this.baseURL + 'Players/' + playerId,patches);
  }

  changeGame(gameId:number,patches:patchModel[]){
    return this.http.patch(this.baseURL + 'Games/' + gameId,patches);
  }

  changeTeam(teamId:number,patches:patchModel[]){
    return this.http.patch(this.baseURL + 'Teams/' + teamId,patches);
  }

}
