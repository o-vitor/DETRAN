import { Injectable} from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, of, BehaviorSubject } from 'rxjs';
import { take, tap, map } from "rxjs/operators"; 
import { environment } from '../../environments/environment';
import { Condutor } from '../_models/condutor';

@Injectable({ providedIn: 'root' })
export class CondutorService {

    public baseUrl = environment.baseUrl + '/api/Condutor';
    private loggedUser: any = null;

    constructor(private httpClient: HttpClient) {
 
    }

    listCondutores (): Observable<Condutor[]> {
        return this.httpClient.get<Condutor[]>(this.baseUrl).pipe()
    }

    getCondutorById (id: number): Observable<Condutor> {
        return this.httpClient.get<Condutor>(`${this.baseUrl}/${id}`).pipe(
            take(1), 
            tap(console.log)
        );
    }

    getCondutorByCpf (cpf: string): Observable<Condutor> {
        return this.httpClient.get<Condutor>(`${this.baseUrl}/cpf/${cpf}`).pipe(
            take(1), 
            tap(console.log)
        );
    }
 
    alterCondutor (id: number, condutor: any) {
        return this.httpClient.put(`${this.baseUrl}/${id}`, condutor).pipe(tap(console.log));
    }

    addCondutor (condutor: any) {
        return this.httpClient.post(this.baseUrl, condutor).pipe(tap(console.log));
    }

    deleteCondutor (id: number) {
        return this.httpClient.delete(`${this.baseUrl}/${id}`).pipe(tap(console.log));
    }
}