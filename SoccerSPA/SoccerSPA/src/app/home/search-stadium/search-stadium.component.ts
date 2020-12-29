import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { game } from 'src/app/models/game';
import { player } from 'src/app/models/player';
import { stadium } from 'src/app/models/stadium';
import { PlayersService } from 'src/app/services/players.service';
import { StadiumService } from 'src/app/services/stadium.service';
@Component({
  selector: 'app-search-stadium',
  templateUrl: './search-stadium.component.html',
  styleUrls: ['./search-stadium.component.css']
})
export class SearchStadiumComponent implements OnInit {

  searchForm:FormGroup;

  constructor(private stadiumService:StadiumService) { }

  initiateForm(){
    this.searchForm = new FormGroup({
      'value':new FormControl('',[Validators.required]),
    })
  }
  stadiums:stadium[]=[];
    ngOnInit(): void {
    this.initiateForm();
  }
  games:game[]=[];
  onSubmit(){
    let value = this.searchForm.get('value').value;
    this.stadiumService.getStadiumById(value).subscribe(data=>{
      this.stadiums = [];
      this.stadiums.push(data);
      this.games = data.games;
    })

  }

}
