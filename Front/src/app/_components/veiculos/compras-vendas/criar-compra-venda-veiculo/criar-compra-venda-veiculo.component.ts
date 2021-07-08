import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Condutor } from '../../../../_models/condutor';
import { Veiculo } from '../../../../_models/veiculo';
import { CondutorService } from '../../../../_services/condutor.service';
import { VeiculoCompraVendaService } from '../../../../_services/veiculo-compra-venda.service';
import { VeiculoService } from '../../../../_services/veiculo.service';

@Component({
  selector: 'app-criar-compra-venda-veiculo',
  templateUrl: './criar-compra-venda-veiculo.component.html',
  styleUrls: ['./criar-compra-venda-veiculo.component.css']
})
export class CriarCompraVendaVeiculoComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private veiculoService: VeiculoService,
    private condutorService: CondutorService,
    private veiculoCompraVendaService: VeiculoCompraVendaService,
    private toastr: ToastrService) { }

  listaCondutores: Condutor[];
  listaVeiculos: Veiculo[];

  veiculoCompraVendaForm = this.fb.group({
		idVeiculo: [0, Validators.required],
		idComprador: [0, Validators.required],
		idVendedor: [0],
		data: ['', Validators.required], 
	});

  listVeiculos() {
    this.veiculoService.listVeiculos().subscribe((data: any)=>{
      this.listaVeiculos = data;
    })  
  }
  listCondutores() {
    this.condutorService.listCondutores().subscribe((data: any)=>{
      this.listaCondutores = data;
    })  
  }

  ngOnInit(): void {
    this.listVeiculos();
    this.listCondutores();
  }

  onSubmit() { 
    const compraVenda = {
			veiculoId: Number(this.veiculoCompraVendaForm.value.idVeiculo),
			condutorCompradorId: Number(this.veiculoCompraVendaForm.value.idComprador),
			condutorVendedorId: Number(this.veiculoCompraVendaForm.value.idVendedor),
			data: this.veiculoCompraVendaForm.value.data, 
		}
		this.veiculoCompraVendaService.addVeiculoCompraVenda(compraVenda).subscribe(
			ret => {
				this.toastr.success('Cadastro realizado com sucesso') 
			},
			err => { 
				this.toastr.error('Não foi possível cadastrar: ' + err.error)
			}
		)
	}
}
