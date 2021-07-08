import { Component, OnInit } from '@angular/core';  
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router'; 
import { ToastrService } from 'ngx-toastr';
import { Condutor } from '../../_models/condutor';
import { CondutorService } from '../../_services/condutor.service';

@Component({
  selector: 'app-condutores',
  templateUrl: './condutores.component.html',
  styleUrls: ['./condutores.component.css']
})
export class CondutoresComponent implements OnInit {

  condutores: Condutor[] = [];

  constructor(public condutorService: CondutorService, private toastr: ToastrService) { }

  ngOnInit() {
    this.listCondutores();
  }

  listCondutores() {
    this.condutorService.listCondutores().subscribe((data: any) => {
      this.condutores = data;
    });
  }

  excluirCondutor (id: any) {
    if(confirm("Tem certeza?")) {
      this.condutorService.deleteCondutor(id).subscribe(
        ret => {
          this.toastr.success('Exclusão realizada com sucesso');
          this.listCondutores();
        },
        err => {
          this.toastr.error('Não foi possível excluir');
        }
      );
    }
  }
}