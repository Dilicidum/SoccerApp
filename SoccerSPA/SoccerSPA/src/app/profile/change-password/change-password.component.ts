import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { passwordValidator } from 'src/app/validators/password.validator';
import { UserService } from 'src/app/services/user.service';
import { changePasswordModel } from 'src/app/models/changePasswordModel';
//import {MatDialog} from '@angular/material/dialog';
//import { PasswordChangeSucessfullyPopUpComponent } from './password-change-sucessfully-pop-up/password-change-sucessfully-pop-up.component';
import { MineService } from 'src/app/services/mine.service';
@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

  changePasswordForm:FormGroup;
  changePasswordModel:changePasswordModel={password:'',passwordConfirmed:'',oldPassword:''};
  constructor(private currentUserService:MineService,private mineService:MineService) { }

  ngOnInit(): void {
    this.changePasswordForm = new FormGroup({
      'oldPassword' : new FormControl('',[Validators.required]),
      'passwords':new FormGroup({
        'password'  : new FormControl('',Validators.required),
        'passwordConfirmed':  new FormControl('',[Validators.required,]),
      },[passwordValidator()])

    })
  }

  passwordChanged:boolean=true;

  onSubmit(){
    this.changePasswordModel.oldPassword = this.changePasswordForm.get('oldPassword').value;
    this.changePasswordModel.password = this.changePasswordForm.get('passwords').get('password').value;
    this.changePasswordModel.passwordConfirmed = this.changePasswordForm.get('passwords').get('passwordConfirmed').value;
    this.mineService.changePassword(this.changePasswordModel).subscribe(data=>{
      this.passwordChanged = true;
      this.changePasswordForm.reset();
      //this.dialog.open(PasswordChangeSucessfullyPopUpComponent,{width:'300px',height:'300px',});
    },error=>{
      this.passwordChanged = false;
    });
  }



}
