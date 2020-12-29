import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { player } from 'src/app/models/player';
import { playerUploadModel } from 'src/app/models/playerUploadModel';
import { UploadService } from 'src/app/services/upload.service';

@Component({
  selector: 'app-add-player',
  templateUrl: './add-player.component.html',
  styleUrls: ['./add-player.component.css']
})
export class AddPlayerComponent implements OnInit {
  player:player={};
  playerUploadModel:playerUploadModel={};
  uploadPlayerForm:FormGroup;
  constructor(private uploadService:UploadService) { }

  ngOnInit(): void {
    this.initiateForm();
  }

  initiateForm(){
    this.uploadPlayerForm = new FormGroup({
      'firstName':new FormControl('', [Validators.required] ),
      'lastName':new FormControl('',   [Validators.required] ),
      'dateOfBirth':new FormControl('',     [Validators.required] ),
      'sallary':new FormControl('',    [Validators.required] ),
      'position':new FormControl('',    [Validators.required] ),
      'country':new FormControl('',     [Validators.required] )
    })
  }

  positions:string[]=[
    'Goalkeeper','defender','Midlfielder','Forward'
  ]

  countries:string[]=[
    'UK',
        'France',
        'Spain',
        'Belgium',
        'Sweden',
        'Germany'
  ]

  onSubmit(){
    this.playerUploadModel.firstName = this.uploadPlayerForm.get('firstName').value;
    this.playerUploadModel.lastName = this.uploadPlayerForm.get('lastName').value;
    this.playerUploadModel.dateOfBirth = this.uploadPlayerForm.get('dateOfBirth').value;
    this.playerUploadModel.sallary = this.uploadPlayerForm.get('sallary').value;
    this.playerUploadModel.position = this.uploadPlayerForm.get('position').value;
    this.playerUploadModel.country = {};
    this.playerUploadModel.country.Name = this.uploadPlayerForm.get('country').value;

    this.uploadService.uploadPlayer(this.playerUploadModel).subscribe(data=>{
      console.log('data response upload = ',data);
    },
    error=>{
      console.log('err = ',error);
    })
  }
}
