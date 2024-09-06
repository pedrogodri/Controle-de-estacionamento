using Api.Dto.TabelaPreco;
using Api.Models;

namespace Api.Services.TabelaPreco
{
    public interface ITabelaPrecoService
    {

        Task<ResponseModel<List<TabelaPrecoModel>>> ListarTabelasPrecos();
        Task<ResponseModel<TabelaPrecoModel>> BuscarTabelaPrecoPorId(int idTabelaPreco);
        Task<ResponseModel<List<TabelaPrecoModel>>> CriarTabelaPreco(TabelaPrecoCriacaoDto tabelaPrecoCriacaoDto);
        Task<ResponseModel<List<TabelaPrecoModel>>> EditarTabelaPreco(TabelaPrecoEdicaoDto tabelaPrecoEdicaoDto);
        Task<ResponseModel<List<TabelaPrecoModel>>> ExcluirTabelaPreco(int idTabelaPreco);
    }
}
