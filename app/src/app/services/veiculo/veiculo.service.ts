import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/models/response-model/response-model';
import { VeiculoEdicaoDto } from 'src/app/models/veiculo/veiculo-edicao-dto';
import { VeiculoEntradaDto } from 'src/app/models/veiculo/veiculo-entrada-dto';
import { VeiculoModel } from 'src/app/models/veiculo/veiculo-model';
import { VeiculoSaidaDto } from 'src/app/models/veiculo/veiculo-saida-dto';

@Injectable({
  providedIn: 'root'
})
export class VeiculoService {
  private idVeiculo: number = 0;
  constructor(private http:HttpClient) { }

  private url:string = 'http://localhost:5107/api/Veiculo';

  listarVeiculos(): Observable<{ dados: VeiculoModel[] }> {
    return this.http.get<{ dados: VeiculoModel[] }>(`${this.url}/Listar`);
  }

  registrarEntrada(veiculoEntradaDto: VeiculoEntradaDto): Observable<ResponseModel<VeiculoEntradaDto>> {
    return this.http.post<ResponseModel<VeiculoEntradaDto>>(`${this.url}/Entrada`, veiculoEntradaDto);
  }

  registrarSaida(veiculoSaidaDto: VeiculoSaidaDto): Observable<ResponseModel<VeiculoSaidaDto>> {
    return this.http.post<ResponseModel<VeiculoSaidaDto>>(`${this.url}/Saida`, veiculoSaidaDto);
  }

  editarVeiculo(VeiculoEdicaoDto: VeiculoEdicaoDto): Observable<ResponseModel<VeiculoEdicaoDto>> {
    return this.http.put<ResponseModel<VeiculoEdicaoDto>>(`${this.url}/EditarVeiculo`, VeiculoEdicaoDto);
  }

  excluirVeiculo(idVeiculo: number): Observable<ResponseModel<VeiculoModel[]>> {
    return this.http.delete<ResponseModel<VeiculoModel[]>>(`${this.url}/ExcluirVeiculo/${idVeiculo}`);
  }

  setVeiculoId(idVeiculo: number) {
    this.idVeiculo = idVeiculo;
  }

  getVeiculoId(): number {
    return this.idVeiculo;
  }
}
