import { Component, OnInit, OnDestroy, ComponentFactoryResolver, ViewChild, ViewContainerRef, ComponentRef } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';
import { userRegistrationModel } from '../models/userRegistrationModel';
import { RegistrationService } from '../services/registration.service';
import { Subscription } from 'rxjs';
import { passwordValidator } from '../validators/password.validator';
import { EmailAsyncValidator } from '../validators/email.validator';
import { CheckService } from '../services/check.service';
import { UserNameUniqueAsyncValidator } from '../validators/username.validator';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit{
  userRegisterModel:userRegistrationModel={};
  registrationForm:FormGroup;
  @ViewChild('genreDynamic',{read:ViewContainerRef})elem:ViewContainerRef;

  constructor(private registrationService:RegistrationService,private authService:AuthenticationService,
    private router:Router,private checkService:CheckService) { }

  ngOnInit(): void {
    this.registrationForm = new FormGroup({
      'firstName':new FormControl('',Validators.required),
      'lastName':new FormControl('',Validators.required),
      'userName':new FormControl('',{
        validators:[Validators.required],
        asyncValidators: UserNameUniqueAsyncValidator.userNameUniqueValidator(this.checkService),
        updateOn:'blur'
      }),
      'email':new FormControl(null,{
        validators:[Validators.required,Validators.email],
        asyncValidators:[EmailAsyncValidator.emailValidator(this.checkService)],
        updateOn:'blur',
      }),
      'dateOfBirth':new FormControl('',Validators.required),
      'passwords':new FormGroup({
        'password':new FormControl('',Validators.required),
        'passwordConfirmed':new FormControl('',[Validators.required]),
      },[Validators.required,passwordValidator()]),
      'genres':new FormControl('')
    })
  }

  get password(){
    if(this.registrationForm !== undefined)
    return this.registrationForm.get('password').value;
  }


  Response:Subscription;

  onSubmit(){
    this.userRegisterModel.firstName = this.registrationForm.get('firstName').value;
    this.userRegisterModel.lastName = this.registrationForm.get('lastName').value;
    this.userRegisterModel.userName = this.registrationForm.get('userName').value;
    this.userRegisterModel.email = this.registrationForm.get('email').value;
    this.userRegisterModel.password = this.registrationForm.get('passwords').get('password').value;
    this.userRegisterModel.confirmedPassword = this.registrationForm.get('passwords').get('passwordConfirmed').value;
    this.userRegisterModel.dateOfBirth = this.registrationForm.get('dateOfBirth').value;
    this.Response = this.registrationService.register(this.userRegisterModel).subscribe(data=>{
      console.log('data =',data);
      this.router.navigateByUrl('');
    })
  }

  lastGenrePicked:string;

}
