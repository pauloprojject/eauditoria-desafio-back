using eaudit.data.Model;
using eaudit.data.Repositorio.Interfaces;
using eaudit.Filtros;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eaudit.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly IRepositorioCrud _repositorio;

        public LocacaoController(IRepositorioCrud repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpPost("CadastrarLocacao")]
        public IActionResult CadastrarLocacao([FromBody] CadastrarLocacaoFiltro filtro)
        {
            try
            {
                Locacao Locacao = new Locacao(filtro.ClienteId, filtro.FilmeId, filtro.DataLocacao, filtro.DataDevolucao);

                _repositorio.CadastrarLocacao(Locacao);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("ConsultarLocacao")]
        public IActionResult ConsultarLocacao([FromQuery] int id)
        {
            try
            {
                Locacao Locacao = _repositorio.ConsultarLocacaoPorId(id);

                return Ok(Locacao);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("AtualizarLocacao")]
        public IActionResult AtualizarLocacao([FromBody] AtualizarLocacaoFiltro filtro)
        {
            try
            {

                Locacao Locacao = _repositorio.ConsultarLocacaoPorId(filtro.Id);

                Locacao.Atualizar(filtro.FilmeId, filtro.ClienteId, filtro.DataDevolucao, filtro.DataLocacao);

                _repositorio.AtualizarLocacao(Locacao);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeletarLocacao")]
        public IActionResult DeletarLocacao([FromQuery] int id)
        {
            try
            {
                _repositorio.DeletarLocacaoPorId(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("TodasLocacoes")]
        public IActionResult TodasLocacoes()
        {
            try
            {
                var locacoes = _repositorio.RetornarTodasLocacoes();

                return Ok(locacoes);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
