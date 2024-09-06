import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/models/response-model/response-model';
import { TabelaPrecoCriacaoDto } from 'src/app/models/tabela-preco/tabela-preco-criacao-dto';
import { TabelaPrecoEdicaoDto } from 'src/app/models/tabela-preco/tabela-preco-edicao-dto';
import { TabelaPrecoModel } from 'src/app/models/tabela-preco/tabela-preco-model';
import { VeiculoModel } from 'src/app/models/veiculo/veiculo-model';

@Injectable({
  providedIn: 'root'
})
export class TabelaPrecoService {

  private idTabelaPreco: number = 0;
  constructor(private http:HttpClient) { }

  private url:string = 'http://localhost:5107/api/TabelaPreco';

  listarTabelasPrecos(): Observable<{ dados: TabelaPrecoModel[] }> {
    return this.http.get<{ dados: TabelaPrecoModel[] }>(`${this.url}/ListarTabelasPrecos`);
  }

  buscarTabelaPrecoPorId(idTabelaPreco: number): Observable<ResponseModel<TabelaPrecoModel>> {
    return this.http.get<ResponseModel<TabelaPrecoModel>>(`${this.url}/BuscarTabelaPrecoPorId/${idTabelaPreco}`);
  }

  criarTabelaPreco(tabelaPrecoCriacaoDto: TabelaPrecoCriacaoDto): Observable<TabelaPrecoCriacaoDto> {
    return this.http.post<TabelaPrecoCriacaoDto>(`${this.url}/CriarTabelaPreco`, tabelaPrecoCriacaoDto);
  }

  editarTabelaPreco(tabelaPrecoEdicaoDto: TabelaPrecoEdicaoDto): Observable<ResponseModel<TabelaPrecoModel>> {
    return this.http.put<ResponseModel<TabelaPrecoModel>>(`${this.url}/EditarTabelaPreco`, tabelaPrecoEdicaoDto);
  }

  excluirTabelaPreco(idTabelaPreco: number): Observable<ResponseModel<TabelaPrecoModel[]>> {
    return this.http.delete<ResponseModel<TabelaPrecoModel[]>>(`${this.url}/ExcluirTabelaPreco/${idTabelaPreco}`);
  }

  getTabelaPrecoById(idTabelaPreco: number): Observable<{ dados: TabelaPrecoEdicaoDto }> {
    return this.http.get<{ dados: TabelaPrecoEdicaoDto }>(`${this.url}/BuscarTabelaPrecoPorId/${idTabelaPreco}`);
  }

  setTabelaPrecoId(idTabelaPreco: number) {
    this.idTabelaPreco = idTabelaPreco;
  }

  getTabelaPrecoId(): number {
    return this.idTabelaPreco;
  }
}
