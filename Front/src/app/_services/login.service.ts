import { Injectable} from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, of, BehaviorSubject } from 'rxjs';
import { take, tap, map } from "rxjs/operators";
import { Usuario } from '../_models/usuario';
import { Router } from '@angular/router';  
import { environment } from '../../environments/environment';


@Injectable({ providedIn: 'root' })
export class LoginService {

    public baseUrl = environment.baseUrl + '/api/Login';
    private loggedUser: any;

    constructor(private httpClient: HttpClient) {
 
    }

    login (email: string, senha: string): Observable<any> { 
        const httpOptions = {
            headers: new HttpHeaders({
              'Content-Type': 'application/json'
            })
          }
        return this.httpClient.post(`${this.baseUrl}`, { email, senha }, httpOptions)
            .pipe(map(response=> {
                sessionStorage.setItem('userData', JSON.stringify(response));
                this.loggedUser = response; 
                return response;
            }));
    }
    
    getLoggedUser() { 
        var data = sessionStorage.getItem('userData');
        if (data) {
            return JSON.parse(sessionStorage.getItem('userData') || '{}');
        }
        return null;
    }

    logout () {
        sessionStorage.removeItem('userData'); 
    } 
}