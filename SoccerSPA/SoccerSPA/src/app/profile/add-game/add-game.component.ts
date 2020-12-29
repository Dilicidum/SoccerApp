import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { game } from 'src/app/models/game';
import { gameUploadModel } from 'src/app/models/gameUploadModel';
import { UploadService } from 'src/app/services/upload.service';

@Component({
  selector: 'app-add-game',
  templateUrl: './add-game.component.html',
  styleUrls: ['./add-game.component.css']
})
export class AddGameComponent implements OnInit {
  game:game={
    house_Team:{},
    guest_Team:{},
    league:{},
    stadium:{},
  };
  uploadGameModel:gameUploadModel={};
  uploadGameForm:FormGroup;
  constructor(private uploadService:UploadService) { }

  gameStatuses:string[]=[
    'NotPlayedYet',
    'Active',
    'Postponed',
    'Completed'
  ]

  gameResults:string[]=[
    'Win',
    'Loss',
    'Draw',
    'NotPlayed'
  ]
  ngOnInit(): void {
    this.initiateForm();
  }

  initiateForm(){
    this.uploadGameForm = new FormGroup({
      'startTime':new FormControl('', [Validators.required] ),
      'houseTeamId':new FormControl('',   [Validators.required] ),
      'guestTeamId':new FormControl('',   [Validators.required] ),
      'stadiumId':new FormControl('',   [Validators.required] ),
      'leagueId':new FormControl('',   [Validators.required] ),
      'amountSoldTickets':new FormControl('',   [Validators.required] ),
      'result':new FormControl('',   [Validators.required] ),
      'status':new FormControl('',   [Validators.required] ),
      'gameResult':new FormControl('',   [Validators.required] ),
    })
  }

  onSubmit(){
    this.uploadGameModel.startTime = this.uploadGameForm.get('startTime').value;
    this.uploadGameModel.house_TeamId = this.uploadGameForm.get('houseTeamId').value;
    this.uploadGameModel.guest_TeamId = this.uploadGameForm.get('guestTeamId').value;
    this.uploadGameModel.stadiumId = this.uploadGameForm.get('stadiumId').value;
    this.uploadGameModel.league_Id   =  this.uploadGameForm.get('leagueId').value;
    this.uploadGameModel.amount_SoldTickets = this.uploadGameForm.get('amountSoldTickets').value;
    this.uploadGameModel.result = this.uploadGameForm.get('result').value;
    this.uploadGameModel.status = this.uploadGameForm.get('status').value;
    this.uploadGameModel.gameResult = this.uploadGameForm.get('gameResult').value;

    this.uploadService.uploadGame(this.uploadGameModel).subscribe(data=>{
      console.log('data response upload = ',data);
    },
    error=>{
      console.log('err = ',error);
    })
  }

}


