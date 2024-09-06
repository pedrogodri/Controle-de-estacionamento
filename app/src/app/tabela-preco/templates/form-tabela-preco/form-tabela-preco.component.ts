import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TabelaPrecoCriacaoDto } from 'src/app/models/tabela-preco/tabela-preco-criacao-dto';
import { TabelaPrecoService } from 'src/app/services/tabela-preco/tabela-preco.service';

@Component({
  selector: 'app-form-tabela-preco',
  templateUrl: './form-tabela-preco.component.html',
  styleUrls: ['./form-tabela-preco.component.scss'],
})
export class FormTabelaPrecoComponent {
  tabelaPreco: TabelaPrecoCriacaoDto;
  idTabelaPreco?: number;

  constructor(private service: TabelaPrecoService, private router: Router) {
    this.tabelaPreco = new TabelaPrecoCriacaoDto();
  }

  ngOnInit(): void {
    this.idTabelaPreco = this.service.getTabelaPrecoId();
    if (this.idTabelaPreco) {
      this.service.getTabelaPrecoById(this.idTabelaPreco).subscribe(
        (response) => {
          // Ajuste para garantir que os dados sejam extraídos corretamente
          this.tabelaPreco = this.mapResponseToTabelaPreco(response.dados);
        },
        (errorResponse) => {
          console.error('Erro ao buscar Tabela de Preço:', errorResponse);
          this.tabelaPreco = new TabelaPrecoCriacaoDto();
        }
      );
    }
  }

  voltarListagem()  {
    this.router.navigate(['lista-tabela-preco']);
  }

  // Método para formatar a data no formato yyyy-MM-dd
  formatDate(date: string | Date): string {
    const dateObj = new Date(date);
    return dateObj.toISOString().split('T')[0];
  }

  // Mapeia a resposta para o formato correto
  private mapResponseToTabelaPreco(data: any): TabelaPrecoCriacaoDto {
    return {
      ...data,
      dataInicio: this.formatDate(data.dataInicio),
      dataFim: this.formatDate(data.dataFim),
    };
  }

  onSubmit(): void {
    if (this.idTabelaPreco) {
      this.service.editarTabelaPreco(this.tabelaPreco).subscribe(
        (response) => {
          console.log('Tabela de Preço editada com sucesso!', response);
        },
        (errorResponse) => {
          console.error('Erro ao editar Tabela de Preço:', errorResponse);
        }
      );
    } else {
      this.service.criarTabelaPreco(this.tabelaPreco).subscribe(
        (response) => {
          console.log('Tabela de Preço criada com sucesso!', response);
          this.tabelaPreco = response;
        },
        (errorResponse) => {
          console.error('Erro ao criar Tabela de Preço:', errorResponse);
        }
      );
    }
  }
}
