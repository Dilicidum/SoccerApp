import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { patchModel } from 'src/app/models/patchModel';
import { player } from 'src/app/models/player';
import { UploadService } from 'src/app/services/upload.service';

@Component({
  selector: 'app-change-player',
  templateUrl: './change-player.component.html',
  styleUrls: ['./change-player.component.css']
})
export class ChangePlayerComponent implements OnInit {
  player:player={};
  uploadPlayerForm:FormGroup;
  constructor(private uploadService:UploadService) { }

  ngOnInit(): void {
    this.initiateForm();
  }

  initiateForm(){
    this.uploadPlayerForm = new FormGroup({
      'playerId':new FormControl('', [Validators.required] ),
      'firstName':new FormControl('',  ),
      'lastName':new FormControl('',   ),
      'dateOfBirth':new FormControl('',  ),
      'sallary':new FormControl('',    ),
      'team':new FormControl('',    ),
    })
  }

  positions:string[]=[
    'Goalkeeper','defender','Midlfielder','Forward'
  ]
  patches:patchModel[]=[];
  countries:string[]=[
    'UK',
        'France',
        'Spain',
        'Belgium',
        'Sweden',
        'Germany'
  ]
  patch:patchModel={};
  onSubmit(){

    this.player.playerId = this.uploadPlayerForm.get('playerId').value;
    console.log('firstName = ',this.uploadPlayerForm.get('firstName').value);
    if(this.uploadPlayerForm.get('firstName').value != ''){
      console.log('FIRSTNAME')
      this.player.firstName = this.uploadPlayerForm.get('firstName').value;
      this.patch.op = "replace";
      this.patch.path="/firstName";
      this.patch.value = this.player.firstName;
      this.patches.push(this.patch)
    }
    if(this.uploadPlayerForm.get('lastName').value != ''){

      this.player.lastName = this.uploadPlayerForm.get('lastName').value;
      this.patch.op = "replace";
      this.patch.path="/lastName";
      this.patch.value = this.player.lastName;
      this.patches.push(this.patch)
    }
    if(this.uploadPlayerForm.get('dateOfBirth').value != ''){
      console.log('DATE')
      this.player.dateOfBirth = this.uploadPlayerForm.get('dateOfBirth').value;
      this.patch.op = "replace";
      this.patch.path="/dateOfBirth";
      this.patch.value = this.player.dateOfBirth;
      this.patches.push(this.patch)
    }
    if(this.uploadPlayerForm.get('sallary').value != ''){
      this.player.sallary = this.uploadPlayerForm.get('sallary').value;
      this.patch.op = "replace";
      this.patch.path="/sallary";
      this.patch.value = this.player.sallary;
      this.patches.push(this.patch)
    }
    if(this.uploadPlayerForm.get('team').value != ''){
      this.player.teamId = this.uploadPlayerForm.get('team').value;
      this.patch.op = "replace";
      this.patch.path="/teamId";
      this.patch.value = this.player.teamId;
      this.patches.push(this.patch)
    }


    this.uploadService.changePlayer(this.player.playerId,this.patches).subscribe(data=>{
      console.log('data response upload = ',data);
    },
    error=>{
      console.log('err = ',error);
    })
  }



}
