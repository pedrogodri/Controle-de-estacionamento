import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormVeiculoComponent } from './templates/form-veiculo/form-veiculo.component';
import { ListaVeiculoComponent } from './templates/lista-veiculo/lista-veiculo.component';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';



@NgModule({
  declarations: [
    FormVeiculoComponent,
    ListaVeiculoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    BrowserModule
  ],
  exports: [
    FormVeiculoComponent,
    ListaVeiculoComponent
  ]
})
export class VeiculoModule { }
