export class VeiculoModel {
    id: number = 0;
    placa?: string;
    dataEntrada?: Date;
    dataSaida?: Date;
    duracao?: string; 
    tempoCobrado?: number; 
    precoHora: number = 0;
    valorTotal: number  = 0;
}
