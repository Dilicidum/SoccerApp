import {Routes} from '@angular/router'
import { AllGamesComponent } from '../all-games/all-games.component'
import { AllplayersComponent } from '../allplayers/allplayers.component'
import { HomeComponent } from '../home/home.component'
import { LoginComponent } from '../login/login.component'
import { AddGameComponent } from '../profile/add-game/add-game.component'
import { AddPlayerComponent } from '../profile/add-player/add-player.component'
import { AddStadiumComponent } from '../profile/add-stadium/add-stadium.component'
import { AddTeamComponent } from '../profile/add-team/add-team.component'
import { ChangeGameComponent } from '../profile/change-game/change-game.component'
import { ChangePasswordComponent } from '../profile/change-password/change-password.component'
import { ChangePlayerComponent } from '../profile/change-player/change-player.component'
import { ChangeStadiumComponent } from '../profile/change-stadium/change-stadium.component'
import { ProfileNavSettingsComponent } from '../profile/profile-nav-settings/profile-nav-settings.component'
import { ProfileComponent } from '../profile/profile.component'
import { RegistrationComponent } from '../registration/registration.component'
import { AuthGuard } from './auth.guard'
export const appRoutes:Routes=[

  {path:'',component:HomeComponent},
  {path:'Registration',component:RegistrationComponent},
  {path:'Login',component:LoginComponent},
  {path:'AllPlayers',component:AllplayersComponent},
      {path:'AllGames',component:AllGamesComponent},
  {
    path:'',
    runGuardsAndResolvers:'always',

    canActivate:[AuthGuard],
    children:[
      {path:'Profile',component:ProfileComponent,canActivate:[AuthGuard],children:[
        {path:'Settings',component:ProfileNavSettingsComponent},
        //{path:'Song/Add',component:AddMusicComponent},

        {path:'Password/Change',component:ChangePasswordComponent},
        {path:'AddPlayer',component:AddPlayerComponent},
        {path:'AddTeam',component:AddTeamComponent},
        {path:'AddStadium',component:AddStadiumComponent},
        {path:'AddGame',component:AddGameComponent},
        {path:'ChangePlayer',component:ChangePlayerComponent},
        {path:'ChangeGame',component:ChangeGameComponent},
        {path:'ChangeStadium',component:ChangeStadiumComponent}
      ]},

      {path:'**',redirectTo:'',pathMatch:'full'}
    ]
  }

]
