import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { userLoginModel } from '../models/userLoginModel';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { error } from 'protractor';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm:FormGroup;
  userLoginModel:userLoginModel = {password:''};
  constructor(private loginService:LoginService,private authenticationService:AuthenticationService,private router:Router) { }

  ngOnInit(): void {
    this.initiateForm();
  }

  showInvalidLoginMessage:boolean=false;

  initiateForm(){
    this.loginForm = new FormGroup(
      {
        'userName':new FormControl('',Validators.required),
        'password':new FormControl('',Validators.required),
      });
  }

  onSubmit(){
    this.showInvalidLoginMessage = false;
    this.detectWayOfLogin();
    this.userLoginModel.userName = this.loginForm.get('userName').value;
    this.userLoginModel.password = this.loginForm.get('password').value;
    this.loginService.logIn(this.userLoginModel).subscribe(data=>{
      console.log('Sucess');
      this.router.navigateByUrl('/Profile');
    },error=>{
      console.log('Error = ',error);
      this.showInvalidLoginMessage = true;
    })


  }

  private detectWayOfLogin(){

  }

}
