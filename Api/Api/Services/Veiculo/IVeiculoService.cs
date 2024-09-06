using Api.Dto.Veiculo;
using Api.Models;

namespace Api.Services.Veiculo
{
    public interface IVeiculoService
    {
        Task<ResponseModel<VeiculoModel>> RegistrarEntrada(VeiculoEntradaDto veiculoEntradaDto);
        Task<ResponseModel<VeiculoModel>> RegistrarSaida(VeiculoSaidaDto veiculoSaidaDto);
        Task<ResponseModel<List<VeiculoModel>>> ListarVeiculos();
    }
}
