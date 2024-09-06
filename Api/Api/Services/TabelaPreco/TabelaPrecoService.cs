using Api.Data;
using Api.Dto.TabelaPreco;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Api.Services.TabelaPreco
{
    public class TabelaPrecoService : ITabelaPrecoService
    {
        private readonly AppDbContext _context;
        public TabelaPrecoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<TabelaPrecoModel>> BuscarTabelaPrecoPorId(int idTabelaPreco)
        {
            ResponseModel<TabelaPrecoModel> resposta = new ResponseModel<TabelaPrecoModel>();

            try
            {
                var tabelapreco = await _context.TabelaPrecos.FirstOrDefaultAsync(tp => tp.Id == idTabelaPreco);
                if(tabelapreco == null)
                {
                    resposta.Mensagem = "Nenhuma Tabela de preço foi coletado";
                    return resposta;
                }
                resposta.Dados = tabelapreco;
                resposta.Mensagem = "Tabela de preço foi coletado";

                return resposta;
            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TabelaPrecoModel>>> CriarTabelaPreco(TabelaPrecoCriacaoDto tabelaPrecoCriacaoDto)
        {
            ResponseModel<List<TabelaPrecoModel>> resposta = new ResponseModel<List<TabelaPrecoModel>>();

            try
            {
                bool exists = await _context.TabelaPrecos.AnyAsync(tp => tp.DataInicio == tabelaPrecoCriacaoDto.DataInicio && tp.DataFim == tabelaPrecoCriacaoDto.DataFim);

                if (exists)
                {
                    resposta.Mensagem = "Já existe uma tabela de preço com as mesmas datas de início e fim.";
                    resposta.Status = false;
                    return resposta;
                }

                var tabelaPreco = new TabelaPrecoModel()
                {
                    DataInicio = tabelaPrecoCriacaoDto.DataInicio,
                    DataFim = tabelaPrecoCriacaoDto.DataFim,
                    ValorHoraInicial = tabelaPrecoCriacaoDto.ValorHoraInicial,
                    ValorHoraAdicional = tabelaPrecoCriacaoDto.ValorHoraAdicional
                };

                _context.Add(tabelaPreco);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.TabelaPrecos.ToListAsync();
                resposta.Mensagem = "Tabela de Preço criado com sucesso";
                return resposta;
            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TabelaPrecoModel>>> EditarTabelaPreco(TabelaPrecoEdicaoDto tabelaPrecoEdicaoDto)
        {
            ResponseModel<List<TabelaPrecoModel>> resposta = new ResponseModel<List<TabelaPrecoModel>>();

            try
            {
                var tabelaPreco = await _context.TabelaPrecos.FirstOrDefaultAsync(tp => tp.Id == tabelaPrecoEdicaoDto.Id);

                if(tabelaPreco == null)
                {
                    resposta.Mensagem = "Nenhuma tabela de preço encontrada";
                    return resposta;
                }

                bool exists = await _context.TabelaPrecos.AnyAsync(tp => tp.Id != tabelaPrecoEdicaoDto.Id 
                                                                   && tp.DataInicio == tabelaPrecoEdicaoDto.DataInicio && tp.DataFim == tabelaPrecoEdicaoDto.DataFim);

                if (exists)
                {
                    resposta.Mensagem = "Já existe outra tabela de preço com as mesmas datas de início e fim.";
                    resposta.Status = false;
                    return resposta;
                }

                tabelaPreco.DataInicio = tabelaPrecoEdicaoDto.DataInicio;
                tabelaPreco.DataFim = tabelaPrecoEdicaoDto.DataFim;
                tabelaPreco.ValorHoraInicial = tabelaPrecoEdicaoDto.ValorHoraInicial;
                tabelaPreco.ValorHoraAdicional = tabelaPrecoEdicaoDto.ValorHoraAdicional;

                _context.Update(tabelaPreco);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.TabelaPrecos.ToListAsync();
                resposta.Mensagem = "Tabela de Preço alterada com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TabelaPrecoModel>>> ExcluirTabelaPreco(int idTabelaPreco)
        {
            ResponseModel<List<TabelaPrecoModel>> resposta = new ResponseModel<List<TabelaPrecoModel>>();

            try
            {
                var tabelaPreco = await _context.TabelaPrecos.FirstOrDefaultAsync(tp => tp.Id == idTabelaPreco);

                if(tabelaPreco == null)
                {
                    resposta.Mensagem = "Nenhuma tabela de preço encontrada";
                    return resposta;
                }

                _context.Remove(tabelaPreco);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.TabelaPrecos.ToListAsync();
                resposta.Mensagem = "Tabela de preço removido com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TabelaPrecoModel>>> ListarTabelasPrecos()
        {
            ResponseModel<List<TabelaPrecoModel>> resposta = new ResponseModel<List<TabelaPrecoModel>>();

            try
            {
                var tabelasprecos = await _context.TabelaPrecos.ToListAsync();
                resposta.Dados = tabelasprecos;
                resposta.Mensagem = "Todos as tabelas de preços foram coletados";

                return resposta;
            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
