import { Component, OnInit } from '@angular/core';
import { gameUploadModel } from 'src/app/models/gameUploadModel';
import { UploadService } from 'src/app/services/upload.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { patchModel } from 'src/app/models/patchModel';
@Component({
  selector: 'app-change-game',
  templateUrl: './change-game.component.html',
  styleUrls: ['./change-game.component.css']
})
export class ChangeGameComponent implements OnInit {
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
      'gameId':new FormControl('', [Validators.required] ),
      'startTime':new FormControl('', ),
      'stadiumId':new FormControl('', ),
      'amountSoldTickets':new FormControl('',),
      'result':new FormControl('',),
    })
  }
  patches:patchModel[]=[];
  patch:patchModel={};
  onSubmit(){
    this.uploadGameModel.gameId = this.uploadGameForm.get('gameId').value;
    if(this.uploadGameForm.get('startTime').value != ''){
      this.uploadGameModel.startTime = this.uploadGameForm.get('startTime').value;
      this.patch.op = "replace";
      this.patch.path="/startTime";
      this.patch.value = this.uploadGameModel.startTime;
      this.patches.push(this.patch)
    }
    if(this.uploadGameForm.get('stadiumId').value != ''){
      this.uploadGameModel.stadiumId = this.uploadGameForm.get('stadiumId').value;
      this.patch.op = "replace";
      this.patch.path="/stadiumId";
      this.patch.value = this.uploadGameModel.stadiumId;
      this.patches.push(this.patch)
    }
    if(this.uploadGameForm.get('amountSoldTickets').value != ''){
      this.uploadGameModel.amount_SoldTickets = this.uploadGameForm.get('amountSoldTickets').value;
      this.patch.op = "replace";
      this.patch.path="/amountSoldTickets";
      this.patch.value = this.uploadGameModel.amount_SoldTickets;
      this.patches.push(this.patch)
    }
    if(this.uploadGameForm.get('result').value != ''){
      this.uploadGameModel.result = this.uploadGameForm.get('result').value;
      this.patch.op = "replace";
      this.patch.path="/result";
      this.patch.value = this.uploadGameModel.result;
      this.patches.push(this.patch)
    }


    this.uploadService.uploadGame(this.uploadGameModel).subscribe(data=>{
      console.log('data response upload = ',data);
    },
    error=>{
      console.log('err = ',error);
    })
  }

}
