import { country } from "./country";
import { team } from "./team";

export interface player{
  playerId?:number;
  firstName?:string;
  lastName?:string;
  dateOfBirth?:Date;
  sallary?:number;
  position?:string;
  country?:country;
  team?:team;
  teamId?:number;

}
