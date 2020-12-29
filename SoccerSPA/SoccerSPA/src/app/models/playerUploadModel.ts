import { country } from "./country";

export interface playerUploadModel{
  playerId?:number;
  firstName?:string;
  lastName?:string;
  dateOfBirth?:Date;
  sallary?:number;
  position?:string;
  country?:country;
}
