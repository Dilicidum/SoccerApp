import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-profile-nav-menu',
  templateUrl: './profile-nav-menu.component.html',
  styleUrls: ['./profile-nav-menu.component.css']
})
export class ProfileNavMenuComponent implements OnInit {

  constructor(private authService:AuthenticationService) { }

  ngOnInit(): void {
  }

  logOut(){
    this.authService.logOut();
  }

}
