import { Component } from '@angular/core';
import { Router } from '@angular/router';
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

  constructor(
    private service: VeiculoService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.service.listarVeiculos().subscribe(
      response => {
        this.veiculos = response.dados;
        console.log("Veículos carregados:", response);
      },
      error => {
        console.error('Erro ao listar veículos:', error);
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
    )
  }

  preparaEdicao(veiculo: VeiculoModel) {
    // Define o veículo selecionado para edição
    this.veiculoSelecionado = { ...veiculo };
  }
  
  editarVeiculo(): void {
    // Envia o veículo atualizado para o backend
    this.service.editarVeiculo(this.veiculoSelecionado).subscribe(
      response => {
        console.log('Veículo editado com sucesso:', response);
        this.ngOnInit(); // Atualiza a lista de veículos
        this.veiculoSelecionado = new VeiculoModel(); // Reseta o formulário
      },
      error => {
        console.error('Erro ao editar o veículo:', error);
      }
    );
  }
  

  cadastrarEntrada(): void {
    this.service.setVeiculoId(0);
    this.service.registrarEntrada(this.veiculoEntrada).subscribe(
      response => {
        console.log('Entrada cadastrada com sucesso:', response);
        this.ngOnInit();
        this.veiculoEntrada = new VeiculoEntradaDto(); // Resetar o formulário
      },
    );
  }

  cadastrarSaida(): void {
    this.service.registrarSaida(this.veiculoSaida).subscribe(
      response => {
        console.log('Saída cadastrada com sucesso:', response);
        this.ngOnInit();
        this.veiculoSaida = new VeiculoSaidaDto(); // Resetar o formulário
      },
    );
  }
}
