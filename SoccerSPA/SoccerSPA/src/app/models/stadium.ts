import { country } from "./country";
import { game } from "./game";

export interface stadium{
  stadiumId?:number;
  name?:string;
  address?:string;
  max_AmountOfViewers?:number;
  price_Per_Seat?:number;
  games?:game[];
}
