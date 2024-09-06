using Api.Dto.Veiculo;
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

        [HttpPost("entrada")]
        public async Task<IActionResult> RegistrarEntrada(VeiculoEntradaDto veiculoEntradaDto)
        {
            var result = await _veiculoService.RegistrarEntrada(veiculoEntradaDto);
            if (!result.Status)
                return BadRequest(result.Mensagem);

            return Ok(result);
        }

        [HttpPost("saida")]
        public async Task<IActionResult> RegistrarSaida(VeiculoSaidaDto veiculoSaidaDto)
        {
            var result = await _veiculoService.RegistrarSaida(veiculoSaidaDto);
            if (!result.Status)
                return BadRequest(result.Mensagem);

            return Ok(result);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarVeiculos()
        {
            var result = await _veiculoService.ListarVeiculos();
            if (!result.Status)
                return BadRequest(result.Mensagem);

            return Ok(result);
        }
    }
}
