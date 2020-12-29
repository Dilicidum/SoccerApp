import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot} from '@angular/router';
import {Router} from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private router:Router,
    private authenticationService:AuthenticationService
  ){}


  canActivate(router:ActivatedRouteSnapshot,state:RouterStateSnapshot){
    if(this.authenticationService.isLoggedIn()){
      return true;
    }
    else{
      this.router.navigateByUrl('/Login');
      return false;
    }
  }
}
