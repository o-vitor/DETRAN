import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { VeiculoService } from '../../../_services/veiculo.service';

@Component({
  selector: 'app-criar-veiculo',
  templateUrl: './criar-veiculo.component.html',
  styleUrls: ['./criar-veiculo.component.css']
})
export class CriarVeiculoComponent implements OnInit {

  veiculoForm = this.fb.group({
		placa: ['', Validators.required],
		modelo: ['', Validators.required],
		marca: ['', Validators.required],
		cor: ['', Validators.required],
		ano: ['', Validators.required],
	});

  constructor(private fb: FormBuilder,
    private veiculoService: VeiculoService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit() { 
		const veiculo = {
			placa: this.veiculoForm.value.placa,
			modelo: this.veiculoForm.value.modelo,
			marca: this.veiculoForm.value.marca,
			cor: this.veiculoForm.value.cor,
			anoFabricacao: this.veiculoForm.value.ano,
		}
		this.veiculoService.addVeiculo(veiculo).subscribe(
			ret => {
				this.toastr.success('Cadastro realizado com sucesso') 
			},
			err => { 
				this.toastr.error('Não foi possível cadastrar: ' + err.error)
			}
		)
	}
}
