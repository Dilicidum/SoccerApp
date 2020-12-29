import { Component, OnInit } from '@angular/core';
import { game } from '../models/game';
import { GamesService } from '../services/games.service';

@Component({
  selector: 'app-all-games',
  templateUrl: './all-games.component.html',
  styleUrls: ['./all-games.component.css']
})
export class AllGamesComponent implements OnInit {
  games:game[]=[];
  newGames:game[]=[];
  constructor(private gameService:GamesService) { }

  ngOnInit(): void {
    this.gameService.getAllGames()
    .subscribe(games=>this.games=games)
  }

  filter:string='';

  getWinGames(){
    this.filter = 'Win';
  }

  sortGamesByDate(){
    this.gameService.getSortedGamesByDate().subscribe(games => this.games = games);
  }

  sortGamesByResult(){
    this.gameService.getSortedGamesByDate().subscribe(games => this.games = games);
  }

}
