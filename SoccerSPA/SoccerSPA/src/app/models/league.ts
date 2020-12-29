import { country } from "./country";
import { game } from "./game";
import { team } from "./team";

export interface league{
  leagueId?:number;
  name?:string;
  timeStart?:Date;
  timeEnd?:Date;
  Countries?:country[];
  statusOfLeague?:string;
  games?:game[];
  teams?:team[];

}
