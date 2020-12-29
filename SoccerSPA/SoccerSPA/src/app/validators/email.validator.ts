import { Component, Directive, Injectable } from "@angular/core";
import { AsyncValidator, ValidationErrors, AbstractControl, NG_ASYNC_VALIDATORS, AsyncValidatorFn } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CheckService } from '../services/check.service';
import { of, Observable } from 'rxjs';
import { map } from 'rxjs/operators';



export class EmailAsyncValidator{

  static emailValidator(checkService:CheckService):AsyncValidatorFn{
    return (control:AbstractControl):Observable<ValidationErrors|null> => {
      return checkService.checkIsEmailUnique(control.value).pipe(
        map(res=>{
          return ( res?  {EmailTaken:true} : null )
        })
      )
    }
  }
}
