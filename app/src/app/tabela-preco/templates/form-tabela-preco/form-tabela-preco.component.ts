import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TabelaPrecoCriacaoDto } from 'src/app/models/tabela-preco/tabela-preco-criacao-dto';
import { TabelaPrecoService } from 'src/app/services/tabela-preco/tabela-preco.service';
import { TabelaPrecoEdicaoDto } from 'src/app/models/tabela-preco/tabela-preco-edicao-dto';

@Component({
  selector: 'app-form-tabela-preco',
  templateUrl: './form-tabela-preco.component.html',
  styleUrls: ['./form-tabela-preco.component.scss'],
})
export class FormTabelaPrecoComponent {
  tabelaPreco: TabelaPrecoCriacaoDto;
  idTabelaPreco?: number;
  message?: string;

  constructor(private service: TabelaPrecoService, private router: Router) {
    this.tabelaPreco = new TabelaPrecoCriacaoDto();
  }

  ngOnInit(): void {
    this.idTabelaPreco = this.service.getTabelaPrecoId();
    if (this.idTabelaPreco) {
      this.service.getTabelaPrecoById(this.idTabelaPreco).subscribe(
        (response) => {
          if (response && response.dados) {
            this.tabelaPreco = this.mapResponseToTabelaPreco(response.dados);
          } else {
            console.error('Dados da Tabela de Preço estão indefinidos.');
            this.tabelaPreco = new TabelaPrecoCriacaoDto();
          }
        },
        (errorResponse) => {
          console.error('Erro ao buscar Tabela de Preço:', errorResponse);
          this.tabelaPreco = new TabelaPrecoCriacaoDto();
        }
      );
    }
  }

  voltarListagem() {
    this.router.navigate(['lista-tabela-preco']);
  }

  formatDate(date: string | Date): string {
    const dateObj = new Date(date);
    return dateObj.toISOString().split('T')[0];
  }

  private mapResponseToTabelaPreco(data: any): TabelaPrecoCriacaoDto {
    return {
      ...data,
      dataInicio: this.formatDate(data.dataInicio),
      dataFim: this.formatDate(data.dataFim),
    };
  }

  onSubmit(): void {
    if (this.idTabelaPreco && this.idTabelaPreco > 0) {
      this.service.editarTabelaPreco(this.tabelaPreco as TabelaPrecoEdicaoDto).subscribe(
        (response) => {
          if (response && response.mensagem) {
            this.message = response.mensagem; 
          }
        }
      );
    } else {
      this.service.criarTabelaPreco(this.tabelaPreco).subscribe(
        (response) => {
          if (response && response.dados) {
            this.message = response.mensagem || 'Tabela de Preço criada com sucesso!';
            this.tabelaPreco = response.dados;
          }
        }
      );
    }
  }
}
