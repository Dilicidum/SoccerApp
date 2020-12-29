import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './helpers/jwt.interceptor';

export const httpInterceptors = [
    {provide:HTTP_INTERCEPTORS, useClass:JwtInterceptor,multi:true},
]
