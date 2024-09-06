import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListaTabelaPrecoComponent } from './tabela-preco/templates/lista-tabela-preco/lista-tabela-preco.component';
import { FormTabelaPrecoComponent } from './tabela-preco/templates/form-tabela-preco/form-tabela-preco.component';

const routes: Routes = [
  { path: '', redirectTo: 'lista-veiculos', pathMatch: 'full' },
  { path: 'lista-tabela-preco', component: ListaTabelaPrecoComponent },
  { path: 'cadastro-tabela-preco', component: FormTabelaPrecoComponent },
  { path: 'editar-tabela-preco', component: FormTabelaPrecoComponent },
  // { path: 'lista-veiculos', component: ListaProjetoComponent },
  // { path: 'cadastro-veiculos', component: CadastroProjetoComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
