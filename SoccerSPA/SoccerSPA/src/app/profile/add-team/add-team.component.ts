import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { team } from 'src/app/models/team';
import { UploadService } from 'src/app/services/upload.service';

@Component({
  selector: 'app-add-team',
  templateUrl: './add-team.component.html',
  styleUrls: ['./add-team.component.css']
})
export class AddTeamComponent implements OnInit {
  team:team={};
  uploadTeamForm:FormGroup;
  constructor(private uploadService:UploadService) { }

  ngOnInit(): void {
    this.initiateForm();
  }

  initiateForm(){
    this.uploadTeamForm = new FormGroup({
      'name':new FormControl('', [Validators.required] ),
      'yearOfCreation':new FormControl('',   [Validators.required] ),
    })
  }

  onSubmit(){
    this.team.name = this.uploadTeamForm.get('name').value;
    this.team.yearOfCreation = this.uploadTeamForm.get('yearOfCreation').value;

    this.uploadService.uploadTeam(this.team).subscribe(data=>{
      console.log('data response upload = ',data);
    },
    error=>{
      console.log('err = ',error);
    })
  }

}
