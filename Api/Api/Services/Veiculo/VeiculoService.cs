using Api.Data;
using Api.Dto.Veiculo;
using Api.Models;
using Api.Services.TabelaPreco;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Veiculo
{
    public class VeiculoService : IVeiculoService
    {
        private readonly AppDbContext _context;
        private readonly ITabelaPrecoService _tabelaPrecoService;

        public VeiculoService(AppDbContext context, ITabelaPrecoService tabelaPrecoService)
        {
            _context = context;
            _tabelaPrecoService = tabelaPrecoService;
        }

        public async Task<ResponseModel<VeiculoModel>> RegistrarEntrada(VeiculoEntradaDto veiculoEntradaDto)
        {
            ResponseModel<VeiculoModel> resposta = new ResponseModel<VeiculoModel>();

            try
            {
                // Verificar se já existe um veículo com a mesma placa que ainda não registrou saída
                var veiculoExistente = await _context.Veiculos
                    .FirstOrDefaultAsync(v => v.Placa == veiculoEntradaDto.Placa && v.DataSaida == null);

                if (veiculoExistente != null)
                {
                    resposta.Mensagem = "Este veículo já está registrado e ainda não foi dado saída.";
                    resposta.Status = false;
                    return resposta;
                }

                // Criar um novo registro de veículo
                var vehicle = new VeiculoModel
                {
                    Placa = veiculoEntradaDto.Placa,
                    DataEntrada = veiculoEntradaDto.DataEntrada
                };

                _context.Veiculos.Add(vehicle);
                await _context.SaveChangesAsync();

                resposta.Dados = vehicle;
                resposta.Mensagem = "Veículo registrado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }


        public async Task<ResponseModel<VeiculoModel>> RegistrarSaida(VeiculoSaidaDto veiculoSaidaDto)
        {
            ResponseModel<VeiculoModel> resposta = new ResponseModel<VeiculoModel>();

            try
            {
                // Buscar o veículo pela placa
                var veiculos = await _context.Veiculos
                    .FirstOrDefaultAsync(v => v.Placa == veiculoSaidaDto.Placa);

                if (veiculos == null)
                {
                    resposta.Mensagem = "Veículo não encontrado.";
                    return resposta;
                }

                veiculos.DataSaida = veiculoSaidaDto.DataSaida;
                veiculos.Duracao = veiculos.DataSaida.Value - veiculos.DataEntrada;

                // Buscar a tabela de preço válida para a data de entrada do veículo
                var tabelaPreco = await _context.TabelaPrecos
                    .FirstOrDefaultAsync(tp => tp.DataInicio <= veiculos.DataEntrada && tp.DataFim >= veiculos.DataEntrada);

                if (tabelaPreco == null)
                {
                    resposta.Mensagem = "Tabela de preço não encontrada para a data de entrada.";
                    return resposta;
                }

                // Calcular o tempo cobrado e o valor total
                decimal duracaoEmHoras = (decimal)veiculos.Duracao.Value.TotalMinutes / 60;
                decimal tempoCobrado = 0;
                decimal valorTotal = 0;

                if (veiculos.Duracao.Value.TotalMinutes <= 30)
                {
                    tempoCobrado = 0.5M; // Cobrar meia hora se <= 30 minutos
                    valorTotal = tabelaPreco.ValorHoraInicial / 2;
                }
                else
                {
                    tempoCobrado = Math.Ceiling(duracaoEmHoras);
                    valorTotal = tabelaPreco.ValorHoraInicial;

                    if (tempoCobrado > 1)
                    {
                        valorTotal += (tempoCobrado - 1) * tabelaPreco.ValorHoraAdicional;
                    }

                    // Aplicar tolerância de 10 minutos para cada hora adicional
                    if (veiculos.Duracao.Value.TotalMinutes % 60 <= 10)
                    {
                        valorTotal -= tabelaPreco.ValorHoraAdicional;
                    }
                }

                veiculos.TempoCobrado = tempoCobrado;
                veiculos.PrecoHora = tabelaPreco.ValorHoraInicial;
                veiculos.ValorTotal = valorTotal;

                _context.Veiculos.Update(veiculos);
                await _context.SaveChangesAsync();

                resposta.Dados = veiculos;
                resposta.Mensagem = "Saída do veículo registrada com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<VeiculoModel>> EditarVeiculo(VeiculoEdicaoDto veiculoEdicaoDto)
        {
            ResponseModel<VeiculoModel> resposta = new ResponseModel<VeiculoModel>();

            try
            {
                // Procurar o veículo pelo ID
                var veiculo = await _context.Veiculos.FirstOrDefaultAsync(v => v.Id == veiculoEdicaoDto.Id);

                if (veiculo == null)
                {
                    resposta.Mensagem = "Veículo não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }

                // Verificar se já existe outro veículo com a mesma placa sem saída registrada
                bool exists = await _context.Veiculos.AnyAsync(v => v.Id != veiculoEdicaoDto.Id && v.Placa == veiculoEdicaoDto.Placa && v.DataSaida == null);

                if (exists)
                {
                    resposta.Mensagem = "Já existe outro veículo com a mesma placa registrado e ainda não foi dado saída.";
                    resposta.Status = false;
                    return resposta;
                }

                // Atualizar as informações do veículo
                veiculo.Placa = veiculoEdicaoDto.Placa;
                veiculo.DataEntrada = veiculoEdicaoDto.DataEntrada;
                veiculo.DataSaida = veiculoEdicaoDto.DataSaida;

                // Atualizar o contexto e salvar as mudanças
                _context.Veiculos.Update(veiculo);
                await _context.SaveChangesAsync();

                resposta.Dados = veiculo;
                resposta.Mensagem = "Veículo atualizado com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<VeiculoModel>>> ExcluirVeiculo(int idVeiculo)
        {
            ResponseModel<List<VeiculoModel>> resposta = new ResponseModel<List<VeiculoModel>>();

            try
            {
                // Procurar o veículo pelo ID
                var veiculo = await _context.Veiculos.FirstOrDefaultAsync(v => v.Id == idVeiculo);

                if (veiculo == null)
                {
                    resposta.Mensagem = "Veículo não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }

                // Remover o veículo do contexto
                _context.Veiculos.Remove(veiculo);
                await _context.SaveChangesAsync();

                // Retornar a lista atualizada de veículos
                resposta.Dados = await _context.Veiculos.ToListAsync();
                resposta.Mensagem = "Veículo removido com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }


        public async Task<ResponseModel<List<VeiculoModel>>> ListarVeiculos()
        {
            ResponseModel<List<VeiculoModel>> resposta = new ResponseModel<List<VeiculoModel>>();

            try
            {
                var veiculos = await _context.Veiculos.ToListAsync();

                if (veiculos == null || !veiculos.Any())
                {
                    resposta.Mensagem = "Nenhum veículo encontrado.";
                    resposta.Status = false;
                    return resposta;
                }

                resposta.Dados = veiculos;
                resposta.Mensagem = "Veículos listados com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

    }
}
