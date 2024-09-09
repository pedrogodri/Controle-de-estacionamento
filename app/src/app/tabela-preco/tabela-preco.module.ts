import { NgModule } from '@angular/core';
import { CommonModule, CurrencyPipe, DatePipe } from '@angular/common';
import { ListaTabelaPrecoComponent } from './templates/lista-tabela-preco/lista-tabela-preco.component';
import { FormTabelaPrecoComponent } from './templates/form-tabela-preco/form-tabela-preco.component';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';



@NgModule({
  declarations: [
    ListaTabelaPrecoComponent,
    FormTabelaPrecoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    BrowserModule
  ],
  exports: [
    ListaTabelaPrecoComponent,
    FormTabelaPrecoComponent
  ],
  providers: [
    DatePipe,
    CurrencyPipe
  ]
})
export class TabelaPrecoModule { }
