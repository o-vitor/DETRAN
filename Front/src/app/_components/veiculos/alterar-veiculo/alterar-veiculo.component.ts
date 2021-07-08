import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Veiculo } from '../../../_models/veiculo';
import { VeiculoService } from '../../../_services/veiculo.service';

@Component({
  selector: 'app-alterar-veiculo',
  templateUrl: './alterar-veiculo.component.html',
  styleUrls: ['./alterar-veiculo.component.css']
})
export class AlterarVeiculoComponent implements OnInit {

  constructor(private route: ActivatedRoute,
    private fb: FormBuilder,
    private veiculoService: VeiculoService,
    private toastr: ToastrService) { }

  veiculoForm = this.fb.group({
		placa: ['', Validators.required],
		modelo: ['', Validators.required],
		marca: ['', Validators.required],
		cor: ['', Validators.required],
		ano: ['', Validators.required],
	});

	idVeiculo : number;
	veiculo: Veiculo;

  ngOnInit(): void {
    this.idVeiculo = Number(this.route.snapshot.paramMap.get('id'));
    this.getVeiculo()
  }

  getVeiculo (): void {
		this.veiculoService.getVeiculoById(this.idVeiculo).subscribe(
			(ret) => {
				if (ret) {
					this.veiculoForm = this.fb.group({
						placa: [ret.placa, Validators.required],
						modelo: [ret.modelo, Validators.required],
						marca: [ret.marca, Validators.required],
						cor: [ret.cor, Validators.required],
						ano: [ret.anoFabricacao, Validators.required],
					});
				} else {
					this.toastr.error('Não foi possível localizar veículo')
				}
			},
			(err) => {
				this.toastr.warning('Não foi possível localizar o veículo')
			}
		);
	}

  onSubmit() {
    const veiculo = {
			placa: this.veiculoForm.value.placa,
			modelo: this.veiculoForm.value.modelo,
			marca: this.veiculoForm.value.marca,
			cor: this.veiculoForm.value.cor,
			anoFabricacao: Number(this.veiculoForm.value.ano),
		}
		this.veiculoService.alterVeiculo(this.idVeiculo, veiculo).subscribe(
			ret => {
				this.toastr.success('Alteração realizada com sucesso') 
			},
			err => {
				this.toastr.error('Não foi possível atualizar veículo: ' + err.error)
			}
		)
  }
}
