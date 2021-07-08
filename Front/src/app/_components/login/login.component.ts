import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../_services/login.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { first } from "rxjs/operators";
import { pipe } from "rxjs";
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  loginForm: FormGroup;

  constructor(private loginService: LoginService, 
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private router: Router) { 

  } 
  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      senha: ['', Validators.required]
    });
  }

  get f() { return this.loginForm.controls; }

  onSubmit() {
    if (this.loginForm.invalid) {
        return;
    }  
    this.loginService.login(this.f.email.value, this.f.senha.value).subscribe((ret: any) => {
        if (ret.token) {   
            this.router.navigate(['home'])  
        }  
    },
    (err) => { 
        this.toastr.error('Erro ao efetuar login: ' + err.error)
    });
  }
}
