import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';  
import { Veiculo } from '../../../../_models/veiculo';
import { VeiculoCompraVendaService } from '../../../../_services/veiculo-compra-venda.service';
import { VeiculoService } from '../../../../_services/veiculo.service';

@Component({
  selector: 'app-veiculos-condutores',
  templateUrl: './veiculos-condutores.component.html',
  styleUrls: ['./veiculos-condutores.component.css']
})
export class VeiculosCondutoresComponent implements OnInit {

  constructor(
    private fb: FormBuilder, 
    private veiculoService: VeiculoService,
    private veiculoCompraVendaService: VeiculoCompraVendaService,
    private toastr: ToastrService) { }

  veiculo: Veiculo;
  comprasVendas: any = []; 

  formBuscar = this.fb.group({
		placa: ['', Validators.required], 
	});

  ngOnInit(): void {
  }

  buscarCondutoresVeiculo() {
    this.veiculoService.getVeiculoByPlaca(this.formBuscar.value.placa).subscribe(ret => {
      this.veiculo = ret;
    });

    this.veiculoCompraVendaService.getComprasVendasVeiculoByPlaca(this.formBuscar.value.placa).subscribe(rc => {
      
      this.comprasVendas = rc; 
     
      if(rc.length == 0) {
        this.toastr.warning('Não existem registros de condutores para esse veículo');
      }

    }, err => {
      this.toastr.error('Erro: ' + err.error)
      this.comprasVendas = []
    })
  }
}
