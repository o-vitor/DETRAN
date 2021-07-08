import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CondutorService } from '../../../_services/condutor.service';

@Component({
  selector: 'app-criar-condutor',
  templateUrl: './criar-condutor.component.html',
  styleUrls: ['./criar-condutor.component.css']
})
export class CriarCondutorComponent implements OnInit {

  condutorForm = this.fb.group({
		nome: ['', Validators.required],
		cpf: ['', Validators.required],
    telefone: [''],
		email: [''],
    dataNascimento: ['', Validators.required],
		cnh: ['', Validators.required],
	});

  constructor(private fb: FormBuilder,
    private condutorService: CondutorService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    
	}

  onSubmit() {

    const condutor = {
			nome: this.condutorForm.value.nome,
			cpf: this.condutorForm.value.cpf,
			telefone: this.condutorForm.value.telefone,
      email: this.condutorForm.value.email,
      dataNascimento: this.condutorForm.value.dataNascimento,
      cnh: this.condutorForm.value.cnh,
		}
		this.condutorService.addCondutor(condutor).subscribe(
			ret => {
				this.toastr.success('Cadastro realizado com sucesso') 
			},
			err => { 
				this.toastr.error('Não foi possível cadastrar: ' + err.error)
			}
		)
  }
}
