import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { stadium } from 'src/app/models/stadium';
import { team } from 'src/app/models/team';
import { UploadService } from 'src/app/services/upload.service';

@Component({
  selector: 'app-add-stadium',
  templateUrl: './add-stadium.component.html',
  styleUrls: ['./add-stadium.component.css']
})
export class AddStadiumComponent implements OnInit {
  stadium:stadium={};
  uploadPlayerForm:FormGroup;
  constructor(private uploadService:UploadService) { }

  ngOnInit(): void {
    this.initiateForm();
  }

  initiateForm(){
    this.uploadPlayerForm = new FormGroup({
      'name':new FormControl('', [Validators.required] ),
      'address':new FormControl('',   [Validators.required] ),
      'max_AmountOfViewers':new FormControl('',     [Validators.required] ),
      'pricePerSeat':new FormControl('',    [Validators.required] )
    })
  }

  onSubmit(){
    this.stadium.name = this.uploadPlayerForm.get('name').value;
    this.stadium.address = this.uploadPlayerForm.get('address').value;
    this.stadium.max_AmountOfViewers = this.uploadPlayerForm.get('max_AmountOfViewers').value;
    this.stadium.price_Per_Seat = this.uploadPlayerForm.get('pricePerSeat').value;

    this.uploadService.uploadStadium(this.stadium).subscribe(data=>{
      console.log('data response upload = ',data);
    },
    error=>{
      console.log('err = ',error);
    })
  }

}
