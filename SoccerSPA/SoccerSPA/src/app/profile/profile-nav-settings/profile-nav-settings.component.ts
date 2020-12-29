import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { user } from 'src/app/models/user';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { CheckService } from 'src/app/services/check.service';
import { MineService } from 'src/app/services/mine.service';
import { UserService } from 'src/app/services/user.service';
import { EmailAsyncValidator } from 'src/app/validators/email.validator';
import { UserNameUniqueAsyncValidator } from 'src/app/validators/username.validator';

@Component({
  selector: 'app-profile-nav-settings',
  templateUrl: './profile-nav-settings.component.html',
  styleUrls: ['./profile-nav-settings.component.css']
})
export class ProfileNavSettingsComponent implements OnInit {

  user:user={};
  profileForm:FormGroup;

  constructor(private checkService:CheckService,private userService:UserService,private currentUserService:MineService) { }

  ngOnInit(): void {
    this.userService.getUserInfo().subscribe(data=>{
      console.log('data = ',data);
      this.user = data;
    },
    error=>{
      console.log('error = ',error);
    })

    this.profileForm = new FormGroup({
      'firstName':new FormControl(this.user.firstName,[]),
      'lastName':new FormControl(this.user.lastName),
      'userName':new FormControl(this.user.userName,{
        validators:[],
        asyncValidators:UserNameUniqueAsyncValidator.userNameUniqueValidator(this.checkService),
        updateOn:'blur'}),
      'email':new FormControl(this.user.email,{
        validators:[Validators.email],
        asyncValidators:EmailAsyncValidator.emailValidator(this.checkService),
        updateOn:'blur',}),
    })
  }

  formIsInvalid:boolean=true;

  isValid(){
    this.profileForm.valueChanges.subscribe(data=>{
      if(data.firstName == '' && data.lastName == '' && data.userName == '' && data.email == ''){
        this.formIsInvalid = true;
      }
      else{
        this.formIsInvalid = false;
      }
    })
    return this.formIsInvalid;
  }

  onChange(){
    this.user.firstName = this.profileForm.get('firstName').value;
    this.user.lastName = this.profileForm.get('lastName').value;
    this.user.email = this.profileForm.get('email').value;
    this.user.userName = this.profileForm.get('userName').value;
    return this.currentUserService.changeUserInfo(this.user).subscribe(data=>{
      console.log('data = ',data);
    })

  }

}
