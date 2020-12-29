import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from'@angular/forms';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import {JwtModule} from '@auth0/angular-jwt';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { appRoutes } from './helpers/routes';
import { AppNavigationComponent } from './app-navigation/app-navigation.component';
import { ValidateHelperComponent } from './validate-helper/validate-helper.component';
import { ProfileComponent } from './profile/profile.component';
import { ChangePasswordComponent } from './profile/change-password/change-password.component';
import { ProfileNavMenuComponent } from './profile/profile-nav-menu/profile-nav-menu.component';
import { ProfileNavSettingsComponent } from './profile/profile-nav-settings/profile-nav-settings.component';
import { httpInterceptors } from './interceptors';
import { AddPlayerComponent } from './profile/add-player/add-player.component';
import { AddTeamComponent } from './profile/add-team/add-team.component';
import { AddStadiumComponent } from './profile/add-stadium/add-stadium.component';
import { ChangePlayerComponent } from './profile/change-player/change-player.component';
import { ChangeStadiumComponent } from './profile/change-stadium/change-stadium.component';
import { ChangeGameComponent } from './profile/change-game/change-game.component';
import { AddGameComponent } from './profile/add-game/add-game.component';
import { AllplayersComponent } from './allplayers/allplayers.component';
import { AllGamesComponent } from './all-games/all-games.component';
import { SearchPlayerComponent } from './home/search-player/search-player.component';
import { SearchStadiumComponent } from './home/search-stadium/search-stadium.component';
import { SearchTeamComponent } from './home/search-team/search-team.component';
export function tokenGetter(){
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RegistrationComponent,
    LoginComponent,
    AppNavigationComponent,
    ValidateHelperComponent,
    ProfileComponent,
    ChangePasswordComponent,
    ProfileNavMenuComponent,
    ProfileNavSettingsComponent,
    AddPlayerComponent,
    AddTeamComponent,
    AddStadiumComponent,
    ChangePlayerComponent,
    ChangeStadiumComponent,
    ChangeGameComponent,
    AddGameComponent,
    AllplayersComponent,
    AllGamesComponent,
    SearchPlayerComponent,
    SearchStadiumComponent,
    SearchTeamComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot(({
      config:{
         tokenGetter:tokenGetter,}
    }))
  ],
  providers: [httpInterceptors],
  bootstrap: [AppComponent]
})
export class AppModule { }
