import { Component, OnInit } from '@angular/core';
import { player } from '../models/player';
import { PlayersService } from '../services/players.service';

@Component({
  selector: 'app-allplayers',
  templateUrl: './allplayers.component.html',
  styleUrls: ['./allplayers.component.css']
})
export class AllplayersComponent implements OnInit {
  players:player[]=[];
  constructor(private playerService:PlayersService) { }

  ngOnInit(): void {
    this.playerService.getAllPlayers().subscribe(players=>{
      this.players = players;
      console.log('players = ',this.players)
    })
  }

}
