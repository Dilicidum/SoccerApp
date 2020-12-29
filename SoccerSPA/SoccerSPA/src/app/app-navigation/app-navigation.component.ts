import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {AuthenticationService} from '../services/authentication.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
@Component({
  selector: 'app-navigation-menu',
  templateUrl: './app-navigation.component.html',
  styleUrls: ['./app-navigation.component.css']
})
export class AppNavigationComponent implements OnInit {
  searchForm:FormGroup;
  constructor(private fb:FormBuilder,public authService:AuthenticationService,
    private router:Router) { }


  ngOnInit(): void {
    this.searchForm = new FormGroup({
      'searchQuery':new FormControl(''),
    });
  }

  isLoggedIn():boolean{
    if(this.authService.isLoggedIn()){
      return true;
    }
    else{
      return false;
    }
  }

}


