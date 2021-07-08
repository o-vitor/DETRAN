import { Injectable} from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, of, BehaviorSubject } from 'rxjs';
import { take, tap, map } from "rxjs/operators"; 
import { environment } from '../../environments/environment';
import { Veiculo } from '../_models/veiculo';

@Injectable({ providedIn: 'root' })
export class VeiculoService {

    public baseUrl = environment.baseUrl + '/api/Veiculo';
    private loggedUser: any = null;

    constructor(private httpClient: HttpClient) {
 
    }

    listVeiculos (): Observable<Veiculo[]> {
        return this.httpClient.get<Veiculo[]>(this.baseUrl).pipe()
    }

    getVeiculoById (id: number): Observable<Veiculo> {
        return this.httpClient.get<Veiculo[]>(`${this.baseUrl}/${id}`).pipe(
            take(1), 
            tap(console.log)
        );
    }

    getVeiculoByPlaca (placa: string): Observable<Veiculo> {
        return this.httpClient.get<Veiculo>(`${this.baseUrl}/placa/${placa}`).pipe(
            take(1), 
            tap(console.log)
        );
    }
 
    alterVeiculo (id: number, veiculo: any) {
        return this.httpClient.put(`${this.baseUrl}/${id}`, veiculo).pipe(tap(console.log));
    }

    addVeiculo (veiculo: any) {
        return this.httpClient.post(this.baseUrl, veiculo).pipe(tap(console.log));
    }

    deleteVeiculo (id: number) {
        return this.httpClient.delete(`${this.baseUrl}/${id}`).pipe(tap(console.log));
    }
}