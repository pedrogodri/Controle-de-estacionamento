import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VeiculoModule } from './veiculo/veiculo.module';
import { TabelaPrecoModule } from './tabela-preco/tabela-preco.module';
import { ComponentsModule } from './components/components.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ComponentsModule,
    VeiculoModule,
    TabelaPrecoModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
