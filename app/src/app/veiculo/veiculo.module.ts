import { NgModule } from '@angular/core';
import { CommonModule, CurrencyPipe, DatePipe } from '@angular/common';
import { ListaVeiculoComponent } from './templates/lista-veiculo/lista-veiculo.component';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  declarations: [
    ListaVeiculoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    BrowserModule
  ],
  exports: [
    ListaVeiculoComponent
  ],
  providers: [
    DatePipe,
    CurrencyPipe
  ]
})
export class VeiculoModule { }
