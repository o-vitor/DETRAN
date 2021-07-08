import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router'; 
import { HomeComponent } from './_components/home/home.component';
import { LoginComponent } from './_components/login/login.component';
import { AuthGuard } from './_guards/auth.guard';
import { VeiculosComponent } from './_components/veiculos/veiculos.component';
import { CriarVeiculoComponent } from './_components/veiculos/criar-veiculo/criar-veiculo.component';
import { AlterarVeiculoComponent } from './_components/veiculos/alterar-veiculo/alterar-veiculo.component';
import { CondutoresComponent } from './_components/condutores/condutores.component';
import { CriarCondutorComponent } from './_components/condutores/criar-condutor/criar-condutor.component';
import { AlterarCondutorComponent } from './_components/condutores/alterar-condutor/alterar-condutor.component';
import { CriarCompraVendaVeiculoComponent } from './_components/veiculos/compras-vendas/criar-compra-venda-veiculo/criar-compra-venda-veiculo.component';
import { VeiculosCondutoresComponent } from './_components/condutores/veiculo/veiculos-condutores/veiculos-condutores.component';
import { CondutoresVeiculosComponent } from './_components/veiculos/condutor/condutores-veiculos/condutores-veiculos.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component:  LoginComponent },
  { path : '', component : LoginComponent },

  { path: 'veiculos', component: VeiculosComponent, canActivate: [AuthGuard] },
  { path: 'veiculos/criar', component: CriarVeiculoComponent, canActivate: [AuthGuard] },
  { path: 'veiculos/editar/:id', component: AlterarVeiculoComponent, canActivate: [AuthGuard] },

  { path: 'condutores', component: CondutoresComponent, canActivate: [AuthGuard] },
  { path: 'condutores/criar', component: CriarCondutorComponent, canActivate: [AuthGuard] },
  { path: 'condutores/editar/:id', component: AlterarCondutorComponent, canActivate: [AuthGuard] },

  { path: 'veiculos/compras-vendas/criar-compra-venda-veiculo', component: CriarCompraVendaVeiculoComponent, canActivate: [AuthGuard] },
  { path: 'veiculos/condutor/condutores-veiculos', component: CondutoresVeiculosComponent, canActivate: [AuthGuard] },

  { path: 'condutores/veiculo/veiculos-condutores', component: VeiculosCondutoresComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }