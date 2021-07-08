import { Injectable} from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, of, BehaviorSubject } from 'rxjs';
import { take, tap, map } from "rxjs/operators"; 
import { environment } from '../../environments/environment';
import { VeiculoCompraVenda } from '../_models/veiculo-compra-venda';

@Injectable({ providedIn: 'root' })
export class VeiculoCompraVendaService {

    public baseUrl = environment.baseUrl + '/api/VeiculoCompraVenda';
    private loggedUser: any = null;

    constructor(private httpClient: HttpClient) {
 
    } 
    addVeiculoCompraVenda (veiculoCompraVenda: any) {
        return this.httpClient.post(this.baseUrl, veiculoCompraVenda).pipe(tap(console.log));
    }
 
    getComprasVendasCondutorByCpf (cpf: string) {
        return this.httpClient.get<VeiculoCompraVenda[]>(`${this.baseUrl}/condutor/${cpf}`).pipe(
            take(1), 
            tap(console.log)
        );
    }

    getComprasVendasVeiculoByPlaca (placa: string) {
        return this.httpClient.get<VeiculoCompraVenda[]>(`${this.baseUrl}/veiculo/${placa}`).pipe(
            take(1), 
            tap(console.log)
        );
    }
 
 
}