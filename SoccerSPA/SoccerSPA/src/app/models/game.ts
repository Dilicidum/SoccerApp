import { league } from "./league";
import { stadium } from "./stadium";
import { team } from "./team";

export interface game{
  gameId?:number;
  startTime?:Date;
  house_Team?:team;
  guest_Team?:team;
  stadium?:stadium;
  amount_Sold_Tickets?:number;
  result?:string;
  status?:string;
  gameResult?:string;
  league?:league;
}
