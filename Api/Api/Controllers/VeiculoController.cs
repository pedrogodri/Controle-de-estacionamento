using Api.Dto.TabelaPreco;
using Api.Dto.Veiculo;
using Api.Models;
using Api.Services.Veiculo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPost("Entrada")]
        public async Task<ActionResult<ResponseModel<VeiculoModel>>> RegistrarEntrada(VeiculoEntradaDto veiculoEntradaDto)
        {
            var result = await _veiculoService.RegistrarEntrada(veiculoEntradaDto);
            if (!result.Status)
                return BadRequest(result.Mensagem);

            return Ok(result);
        }

        [HttpPost("Saida")]
        public async Task<ActionResult<ResponseModel<VeiculoModel>>> RegistrarSaida(VeiculoSaidaDto veiculoSaidaDto)
        {
            var result = await _veiculoService.RegistrarSaida(veiculoSaidaDto);
            if (!result.Status)
                return BadRequest(result.Mensagem);

            return Ok(result);
        }

        [HttpPut("EditarVeiculo")]
        public async Task<ActionResult<ResponseModel<VeiculoModel>>> EditarTabelaPreco(VeiculoEdicaoDto veiculoEdicaoDto)
        {
            var veiculo = await _veiculoService.EditarVeiculo(veiculoEdicaoDto);
            return Ok(veiculo);
        }

        [HttpDelete("ExcluirVeiculo/{idVeiculo}")]
        public async Task<ActionResult<ResponseModel<List<VeiculoModel>>>> ExcluirTabelaPreco(int idVeiculo)
        {
            var veiculo = await _veiculoService.ExcluirVeiculo(idVeiculo);
            return Ok(veiculo);
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<ResponseModel<List<VeiculoModel>>>> ListarVeiculos()
        {
            var result = await _veiculoService.ListarVeiculos();
            if (!result.Status)
                return BadRequest(result.Mensagem);

            return Ok(result);
        }
    }
}
