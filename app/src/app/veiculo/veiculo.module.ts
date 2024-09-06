import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormVeiculoComponent } from './templates/form-veiculo/form-veiculo.component';
import { ListaVeiculoComponent } from './templates/lista-veiculo/lista-veiculo.component';



@NgModule({
  declarations: [
    FormVeiculoComponent,
    ListaVeiculoComponent
  ],
  imports: [
    CommonModule
  ]
})
export class VeiculoModule { }
