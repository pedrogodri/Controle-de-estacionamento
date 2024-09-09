import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { VeiculoEntradaDto } from 'src/app/models/veiculo/veiculo-entrada-dto';
import { VeiculoModel } from 'src/app/models/veiculo/veiculo-model';
import { VeiculoSaidaDto } from 'src/app/models/veiculo/veiculo-saida-dto';
import { VeiculoService } from 'src/app/services/veiculo/veiculo.service';

@Component({
  selector: 'app-lista-veiculo',
  templateUrl: './lista-veiculo.component.html',
  styleUrls: ['./lista-veiculo.component.scss']
})
export class ListaVeiculoComponent {
  veiculos: VeiculoModel[] = [];
  veiculoEntrada: VeiculoEntradaDto = new VeiculoEntradaDto();
  veiculoSaida: VeiculoSaidaDto = new VeiculoSaidaDto();
  veiculoSelecionado: VeiculoModel = new VeiculoModel();
  
  mensagemEntrada?: string = ''; 
  tipoAlertaEntrada: string = ''; 
  
  mensagemSaida?: string = ''; 
  tipoAlertaSaida: string = '';
  
  mensagemEdicao?: string = ''; 
  tipoAlertaEdicao: string = '';

  constructor(
    private service: VeiculoService,
    private datePipe: DatePipe, 
    private currencyPipe: CurrencyPipe
  ) {}

  ngOnInit(): void {
    this.service.listarVeiculos().subscribe(
      response => {
        this.veiculos = response.dados;
        console.log("Veículos carregados:", response);
      }
    );
  }

  preparaDelecao(veiculo: VeiculoModel) {
    this.veiculoSelecionado = veiculo;
  }
  
  excluirTabelaPreco() {
    this.service.excluirVeiculo(this.veiculoSelecionado.id).subscribe(
      response => {
        this.ngOnInit();
      },
      error => {
        this.mensagemEdicao = 'Erro ao excluir o veículo.';
        this.tipoAlertaEdicao = 'danger';
      }
    );
  }

  preparaEdicao(veiculo: VeiculoModel) {
    this.veiculoSelecionado = { ...veiculo };
  }
  
  editarVeiculo(): void {
    this.service.editarVeiculo(this.veiculoSelecionado).subscribe(
      response => {
        this.mensagemEdicao = response.mensagem;
        this.tipoAlertaEdicao = 'success';
        this.ngOnInit(); 
        this.veiculoSelecionado = new VeiculoModel(); 
      },
      error => {
        this.mensagemEdicao = 'Erro ao editar o veículo.';
        this.tipoAlertaEdicao = 'danger';
      }
    );
  }

  formatDate(dateTime?: string | Date): string {
    return dateTime ? this.datePipe.transform(dateTime, 'dd/MM/yyyy HH:mm:ss') || '' : '';
  }

  formatCurrency(value: number): string {
    return this.currencyPipe.transform(value, 'BRL', 'symbol', '1.2-2') || '';
  }

  cadastrarEntrada(): void {
    this.service.setVeiculoId(0);
    this.service.registrarEntrada(this.veiculoEntrada).subscribe(
      response => {
        this.mensagemEntrada = response.mensagem;
        this.tipoAlertaEntrada = 'success';
        this.ngOnInit();
        this.veiculoEntrada = new VeiculoEntradaDto(); 
      },
      error => {
        this.mensagemEntrada = 'Erro ao cadastrar entrada.';
        this.tipoAlertaEntrada = 'danger';
      }
    );
  }

  cadastrarSaida(): void {
    this.service.registrarSaida(this.veiculoSaida).subscribe(
      response => {
        this.mensagemSaida = response.mensagem;
        this.tipoAlertaSaida = 'success'; 
        this.ngOnInit();
        this.veiculoSaida = new VeiculoSaidaDto();
      },
      error => {
        this.mensagemSaida = 'Erro ao cadastrar saída.';
        this.tipoAlertaSaida = 'danger';
      }
    );
  }
}