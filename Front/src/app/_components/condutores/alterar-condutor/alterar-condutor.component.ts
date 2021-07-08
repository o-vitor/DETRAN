import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr'; 
import { Condutor } from '../../../_models/condutor';
import { CondutorService } from '../../../_services/condutor.service';

@Component({
  selector: 'app-alterar-condutor',
  templateUrl: './alterar-condutor.component.html',
  styleUrls: ['./alterar-condutor.component.css']
})
export class AlterarCondutorComponent implements OnInit {

  condutorForm = this.fb.group({
		nome: ['', Validators.required],
		cpf: ['', Validators.required],
    telefone: [''],
		email: [''],
    dataNascimento: [new Date(), Validators.required],
		cnh: ['', Validators.required],
	});

  constructor(private route: ActivatedRoute,
    private fb: FormBuilder,
    private condutorService: CondutorService,
    private toastr: ToastrService) { }

    idCondutor : number;
    condutor: Condutor;
  
    ngOnInit(): void {
      this.idCondutor = Number(this.route.snapshot.paramMap.get('id'));
      this.getcondutor()
    }
  
    getcondutor (): void {
      this.condutorService.getCondutorById(this.idCondutor).subscribe(
        (ret) => {
          if (ret) { 
              this.condutorForm = this.fb.group({
                nome: [ret.nome, Validators.required],
                cpf: [ret.cpf, Validators.required],
                telefone: [ret.telefone, Validators.required],
                email: [ret.email],
                dataNascimento: [ret.dataNascimento, Validators.required],
                cnh: [ret.cnh, Validators.required],
              });
          } else {
            this.toastr.error('Não foi possível localizar condutor')
          }
        },
        (err) => {
          this.toastr.warning('Não foi possível localizar o condutor')
        }
      );
    }
  
    onSubmit() {
      const condutor = {
        nome: this.condutorForm.value.nome,
        cpf: this.condutorForm.value.cpf,
        email: this.condutorForm.value.email,
        telefone: this.condutorForm.value.telefone,
        dataNascimento: this.condutorForm.value.dataNascimento,
        cnh: this.condutorForm.value.cnh,
      }
      this.condutorService.alterCondutor(this.idCondutor, condutor).subscribe(
        ret => {
          this.toastr.success('Alteração realizada com sucesso') 
        },
        err => { 
          this.toastr.error('Não foi possível alterar condutor: ' + err.error)
        }
      )
    }

}
