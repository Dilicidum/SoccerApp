import { ValidatorFn, AbstractControl } from '@angular/forms';

export function passwordValidator():ValidatorFn{
  return (control:AbstractControl):{[key:string]:boolean} | null => {
    let password = control.get('password').value;
    let passwordConfirmed = control.get('passwordConfirmed').value;
    if(passwordConfirmed != password){
      return {"PasswordDoesNotMatch":true}
    }
    else{
      return null;
    }
  }
}
