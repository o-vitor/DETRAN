import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Injectable } from '@angular/core';
import { LoginService } from '../_services/login.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
 
  constructor(private loginService: LoginService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const loggedUser = this.loginService.getLoggedUser();
        if (loggedUser) {
            const token: string = loggedUser.token;
            let reClone;
            if (token) {
            reClone = request.clone({
                headers: request.headers.set('Authorization', 'Bearer ' + token)
            }); 
            return next.handle(reClone);
            }
        }
        return next.handle(request);
    }
}