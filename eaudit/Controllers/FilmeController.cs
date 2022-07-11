using eaudit.data.Model;
using eaudit.data.Repositorio.Interfaces;
using eaudit.Filtros;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eaudit.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IRepositorioCrud _repositorio;

        public FilmeController(IRepositorioCrud repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpPost("CadastrarFilme")]
        public IActionResult CadastrarFilme([FromBody] CadastrarFilmeFiltro filtro)
        {
            try
            {
                Filme Filme = new Filme(filtro.Titulo, filtro.ClassificacaoIndicativa, filtro.Lancamento);

                _repositorio.CadastrarFilme(Filme);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("ConsultarFilme")]
        public IActionResult ConsultarFilme([FromQuery] int id)
        {
            try
            {
                Filme Filme = _repositorio.ConsultarFilmePorId(id);

                return Ok(Filme);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("AtualizarFilme")]
        public IActionResult AtualizarFilme([FromBody] AtualizarFilmeFiltro filtro)
        {
            try
            {

                Filme Filme = _repositorio.ConsultarFilmePorId(filtro.Id);

                Filme.Atualizar(filtro.Titulo, filtro.ClassificacaoIndicativa, filtro.Lancamento);

                _repositorio.AtualizarFilme(Filme);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeletarFilme")]
        public IActionResult DeletarFilme([FromQuery] int id)
        {
            try
            {
                _repositorio.DeletarFilmePorId(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("TodosFilmes")]
        public IActionResult TodosFilmes()
        {
            try
            {
                var filmes = _repositorio.RetornarTodosFilmes();

                return Ok(filmes);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
