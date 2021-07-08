import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr'; 
import { Condutor } from '../../../../_models/condutor';
import { CondutorService } from '../../../../_services/condutor.service';
import { VeiculoCompraVendaService } from '../../../../_services/veiculo-compra-venda.service';

@Component({
  selector: 'app-condutores-veiculos',
  templateUrl: './condutores-veiculos.component.html',
  styleUrls: ['./condutores-veiculos.component.css']
})
export class CondutoresVeiculosComponent implements OnInit {

  constructor(
    private fb: FormBuilder, 
    private condutorService: CondutorService,
    private veiculoCompraVendaService: VeiculoCompraVendaService,
    private toastr: ToastrService) { }

  condutor: Condutor;
  comprasVendas: any = []; 

  formBuscar = this.fb.group({
		cpf: ['', Validators.required], 
	});


  ngOnInit(): void {
  }

  buscarVeiculosCondutor() {
    this.condutorService.getCondutorByCpf(this.formBuscar.value.cpf).subscribe(ret => {
      this.condutor = ret;
    });

    this.veiculoCompraVendaService.getComprasVendasCondutorByCpf(this.formBuscar.value.cpf).subscribe(rc => {
      this.comprasVendas = rc; 
    }, err => {
      this.toastr.error('Erro: ' + err.error)
      this.comprasVendas = []
    })
  }
}
