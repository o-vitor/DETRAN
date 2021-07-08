import { Component, OnInit } from '@angular/core';  
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Veiculo } from '../../_models/veiculo';
import { VeiculoService } from '../../_services/veiculo.service';

@Component({
  selector: 'app-veiculos',
  templateUrl: './veiculos.component.html',
  styleUrls: ['./veiculos.component.css']
})
export class VeiculosComponent implements OnInit {
 
  veiculos: Veiculo[] = [];

  constructor(public veiculoService: VeiculoService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.listVeiculos();
  }

  listVeiculos() {
    this.veiculoService.listVeiculos().subscribe((data: any)=>{
      this.veiculos = data;
    })  
  }

  excluirVeiculo(id: any) {
    if(confirm("Tem certeza?")) {
      this.veiculoService.deleteVeiculo(id).subscribe(
        ret => {
          this.toastr.success('Exclusão realizada com sucesso');
          this.listVeiculos();
        },
        err => {
          this.toastr.error('Não foi possível excluir');
        }
      );
    }
  }
}
