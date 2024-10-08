import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TabelaPrecoModel } from 'src/app/models/tabela-preco/tabela-preco-model';
import { TabelaPrecoService } from 'src/app/services/tabela-preco/tabela-preco.service';
import { CurrencyPipe, DatePipe } from '@angular/common';

@Component({
  selector: 'app-lista-tabela-preco',
  templateUrl: './lista-tabela-preco.component.html',
  styleUrls: ['./lista-tabela-preco.component.scss'],
  providers: [DatePipe]
})
export class ListaTabelaPrecoComponent {
  tabelaPrecos?: TabelaPrecoModel[] = [];
  tabelaPrecoSelecionado: TabelaPrecoModel = new TabelaPrecoModel();

  constructor(
    private service: TabelaPrecoService, 
    private router: Router, 
    private datePipe: DatePipe,
    private currencyPipe: CurrencyPipe
  ) {}

  ngOnInit(): void {
    this.service.listarTabelasPrecos().subscribe(
      response => {
        this.tabelaPrecos = response.dados;
        console.log("aqui", response);
      },
      error => {
        console.error('Erro ao listar tabelas de preços:', error);
      }
    );
  }
  

  novaTabelaPreco(): void {
    this.service.setTabelaPrecoId(0);
    this.router.navigate(['cadastro-tabela-preco']);
  }

  editarTabelaPreco(idTabelaPreco: number): void {
    this.service.setTabelaPrecoId(idTabelaPreco);
    this.router.navigate(['editar-tabela-preco'])
  }

  preparaDelecao(tabelaPrecos: TabelaPrecoModel) {
    this.tabelaPrecoSelecionado = tabelaPrecos;
  }

  excluirTabelaPreco() {
    this.service.excluirTabelaPreco(this.tabelaPrecoSelecionado.id).subscribe(
      response => {
        this.ngOnInit();
      },
    )
  }

  formatDateTime(dateTime?: string | Date): string {
    return dateTime ? this.datePipe.transform(dateTime, 'dd/MM/yyyy HH:mm:ss') || '' : '';
  }

  formatCurrency(value: number): string {
    return this.currencyPipe.transform(value, 'BRL', 'symbol', '1.2-2') || '';
  }
}