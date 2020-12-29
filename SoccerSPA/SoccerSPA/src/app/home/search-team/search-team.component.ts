import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { game } from 'src/app/models/game';
import { team } from 'src/app/models/team';
import { TeamService } from 'src/app/services/team.service';

@Component({
  selector: 'app-search-team',
  templateUrl: './search-team.component.html',
  styleUrls: ['./search-team.component.css']
})
export class SearchTeamComponent implements OnInit {
  searchForm:FormGroup;
  constructor(private teamService:TeamService) { }

  ngOnInit(): void {
    this.initiateForm();
  }
  games:game[]=[];
  initiateForm(){
    this.searchForm =new FormGroup({
      'Id':new FormControl('',[Validators.required]),
      'date':new FormControl('',[Validators.required])
    })
  }

  onSubmit(){
    let id = this.searchForm.get('Id').value;
    let date = this.searchForm.get('date').value;
    this.teamService.getGameByDate(id,date).subscribe(data=>{
      this.games = [];
      this.games = data;
    })

  }

}
