import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

// Bootstrap
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

// Material
import { MaterialModule } from './material.module';

// Toastr
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

// Form
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// PrimeNG table
import { TableModule } from 'primeng/table';

// Botões
import { BotaoNovoComponent } from './_components/botao-novo/botao-novo.component';
import { BotaoVoltarComponent } from './_components/botao-voltar/botao-voltar.component';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './_components/login/login.component';
import { HomeComponent } from './_components/home/home.component';
import { VeiculosComponent } from './_components/veiculos/veiculos.component';
import { CriarVeiculoComponent } from './_components/veiculos/criar-veiculo/criar-veiculo.component';
import { AlterarVeiculoComponent } from './_components/veiculos/alterar-veiculo/alterar-veiculo.component';
import { CondutoresComponent } from './_components/condutores/condutores.component';
import { CriarCondutorComponent } from './_components/condutores/criar-condutor/criar-condutor.component';
import { AlterarCondutorComponent } from './_components/condutores/alterar-condutor/alterar-condutor.component';
import { CriarCompraVendaVeiculoComponent } from './_components/veiculos/compras-vendas/criar-compra-venda-veiculo/criar-compra-venda-veiculo.component';
import { CondutoresVeiculosComponent } from './_components/veiculos/condutor/condutores-veiculos/condutores-veiculos.component';
import { VeiculosCondutoresComponent } from './_components/condutores/veiculo/veiculos-condutores/veiculos-condutores.component';

// Services
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { TokenInterceptor } from './_helpers/interceptor';
import { LoginService } from './_services/login.service';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent, 
    VeiculosComponent, CondutoresComponent, BotaoNovoComponent, CriarVeiculoComponent, AlterarVeiculoComponent, 
    CriarCondutorComponent, AlterarCondutorComponent, 
    CriarCompraVendaVeiculoComponent, CondutoresVeiculosComponent, VeiculosCondutoresComponent, BotaoVoltarComponent, 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    FormsModule, 
    NgbModule,
    BrowserAnimationsModule,
    FontAwesomeModule,
    ToastrModule.forRoot({timeOut: 5000}),
    TableModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [LoginService, 
    {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi : true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
