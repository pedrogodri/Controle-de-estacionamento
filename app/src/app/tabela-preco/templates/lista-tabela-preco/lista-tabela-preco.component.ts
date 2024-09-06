import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TabelaPrecoModel } from 'src/app/models/tabela-preco/tabela-preco-model';
import { TabelaPrecoService } from 'src/app/services/tabela-preco/tabela-preco.service';
import { CurrencyPipe, DatePipe } from '@angular/common'; // Importar o DatePipe

@Component({
  selector: 'app-lista-tabela-preco',
  templateUrl: './lista-tabela-preco.component.html',
  styleUrls: ['./lista-tabela-preco.component.scss'],
  providers: [DatePipe] // Adicione o DatePipe aos providers
})
export class ListaTabelaPrecoComponent {
  tabelaPrecos?: TabelaPrecoModel[] = [];

  constructor(
    private service: TabelaPrecoService, 
    private router: Router, 
    private datePipe: DatePipe,
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

  formatDateTime(dateTime?: string | Date): string {
    return dateTime ? this.datePipe.transform(dateTime, 'dd/MM/yyyy HH:mm:ss') || '' : '';
  }
}