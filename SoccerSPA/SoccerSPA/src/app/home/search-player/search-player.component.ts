import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { player } from 'src/app/models/player';
import { PlayersService } from 'src/app/services/players.service';

@Component({
  selector: 'app-search-player',
  templateUrl: './search-player.component.html',
  styleUrls: ['./search-player.component.css']
})

export class SearchPlayerComponent implements OnInit {
  searchForm:FormGroup;
  searchOptions:string[]=[
    'Id','First Name','Last Name'
  ]
  constructor(private playerService:PlayersService) { }

  initiateForm(){
    this.searchForm = new FormGroup({
      'value':new FormControl('',[Validators.required]),
      'option':new FormControl('',[Validators.required])
    })
  }
  players:player[]=[];
    ngOnInit(): void {
    this.initiateForm();
  }

  onSubmit(){
    let value = this.searchForm.get('value').value;
    let option = this.searchForm.get('option').value;
    if(option == 'Id'){
      this.playerService.getPlayerById(value).subscribe(data=>{
        this.players = [];
        this.players.push(data)
      });
    }
    if(option == 'First Name'){
      this.playerService.getPlayersByFirstName(value).subscribe(data=>{
        this.players = [];
        this.players = data;
      });
    }
    if(option == 'Last Name'){
      this.playerService.getPlayersByLastName(value).subscribe(data=>{
        this.players = [];
        this.players = data;
      });
    }

  }

}
