import { AsyncValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';
import { CheckService } from '../services/check.service';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

export class UserNameUniqueAsyncValidator{
  static userNameUniqueValidator(checkService:CheckService):AsyncValidatorFn{
    return (control:AbstractControl):Observable<ValidationErrors|null> => {
      return checkService.checkIsUserNameIsUnique(control.value).pipe(
        map(response=>{
          return (!response ? {UserNameTaken:true} : null)
        })
      )
    }
  }
}
