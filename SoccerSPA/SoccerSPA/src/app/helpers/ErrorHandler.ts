import { Observable, throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

export function handlerError(error:HttpErrorResponse){
  if(error.error instanceof ErrorEvent){
    console.log('Something bad happened on the UI, message:',error.message);
  }else{
    console.log('Something bad happened on back-end, status: ',error.status );
    console.log('Body of error:',error.message);
  }
  return throwError('Something bad happened:');
}
