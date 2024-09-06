using Api.Dto.TabelaPreco;
using Api.Models;
using Api.Services.TabelaPreco;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaPrecoController : ControllerBase
    {
        private readonly ITabelaPrecoService _tabelaPrecoService;
        public TabelaPrecoController(ITabelaPrecoService tabelaPrecoService)
        {
            _tabelaPrecoService = tabelaPrecoService;
        }

        [HttpGet("ListarTabelasPrecos")]
        public async Task<ActionResult<ResponseModel<List<TabelaPrecoModel>>>> ListarTabelasPrecos()
        {
            var tabelasPrecos = await _tabelaPrecoService.ListarTabelasPrecos();
            return Ok(tabelasPrecos);
        }

        [HttpGet("BuscarTabelaPrecoPorId/{idTabelaPreco}")]
        public async Task<ActionResult<ResponseModel<TabelaPrecoModel>>> BuscarTabelaPrecoPorId(int idTabelaPreco)
        {
            var tabelaPreco = await _tabelaPrecoService.BuscarTabelaPrecoPorId(idTabelaPreco);
            return Ok(tabelaPreco);
        }

        [HttpPost("CriarTabelaPreco")]
        public async Task<ActionResult<ResponseModel<List<TabelaPrecoModel>>>> CriarTabelaPreco(TabelaPrecoCriacaoDto tabelaPrecoCriacaoDto)
        {
            var tabelasprecos = await _tabelaPrecoService.CriarTabelaPreco(tabelaPrecoCriacaoDto);
            return Ok(tabelasprecos);
        }

        [HttpPut("EditarTabelaPreco")]
        public async Task<ActionResult<ResponseModel<List<TabelaPrecoModel>>>> EditarTabelaPreco(TabelaPrecoEdicaoDto tabelaPrecoEdicaoDto)
        {
            var tabelasprecos = await _tabelaPrecoService.EditarTabelaPreco(tabelaPrecoEdicaoDto);
            return Ok(tabelasprecos);
        }

        [HttpDelete("ExcluirTabelaPreco")]
        public async Task<ActionResult<ResponseModel<List<TabelaPrecoModel>>>> ExcluirTabelaPreco(int idTabelaPreco)
        {
            var tabelasprecos = await _tabelaPrecoService.ExcluirTabelaPreco(idTabelaPreco);
            return Ok(tabelasprecos);
        }
    }
}
