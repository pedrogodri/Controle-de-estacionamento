import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListaTabelaPrecoComponent } from './templates/lista-tabela-preco/lista-tabela-preco.component';
import { FormTabelaPrecoComponent } from './templates/form-tabela-preco/form-tabela-preco.component';



@NgModule({
  declarations: [
    ListaTabelaPrecoComponent,
    FormTabelaPrecoComponent
  ],
  imports: [
    CommonModule
  ]
})
export class TabelaPrecoModule { }
