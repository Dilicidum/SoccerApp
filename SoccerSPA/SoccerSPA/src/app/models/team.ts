import { player } from "./player";

export interface team{
  teamId?:number;
  name?:string;
  yearOfCreation?:number;
  players?:player[];

}
