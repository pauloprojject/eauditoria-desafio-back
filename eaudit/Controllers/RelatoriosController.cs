using eaudit.data.Model.Respostas;
using eaudit.data.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eaudit.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RelatoriosController : Controller
    {
        private readonly IRepositorioRelatorios _repositorio;

        public RelatoriosController(IRepositorioRelatorios repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("RelatorioDeSegundoClienteComMaisLocacoes")]
        public IActionResult SegundoCliente()
        {
            try
            {
                var cliente = _repositorio.SegundoClienteMaisLocacoes();

                return Ok(cliente);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("RelatorioDeFilmesSemLocacoes")]
        public IActionResult FilmesSemLocacoes()
        {
            try
            {
                var filmes = _repositorio.FilmesSemLocacoes();

                return Ok(filmes);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("RelatorioDeTresFilmesMenosAlugadosNaSemana")]
        public IActionResult TresFilmesMenosAlugados()
        {
            try
            {
                var filmes = _repositorio.TresFilmesMenosAlugados();

                return Ok(filmes);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("RelatorioDeCincoFilmesMaisAlugadosNoAno")]
        public IActionResult CincoFilmesMaisAlugadosAno()
        {
            try
            {
                var filmes = _repositorio.CincoFilmesMaisAlugadosNoAno();

                return Ok(filmes);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("RelatorioDeClientesEmAtraso")]
        public IActionResult ClientesEmAtraso()
        {
            try
            {
                var clientes = _repositorio.ClientesAtraso();
                var retorno = new List<RespostaClienteAtraso>();

                foreach(var cliente in clientes)
                {
                    foreach(var locacao in cliente.Locacoes)
                    {
                        if(locacao.Filme.Lancamento == 0)
                        {
                            if((locacao.DataDevolucao - locacao.DataLocacao).Days > 2)
                            {
                                retorno.Add(new RespostaClienteAtraso { Id = cliente.Id, Nome = cliente.Nome, Cpf = cliente.Cpf, DataNascimento = cliente.DataNascimento });
                            }
                        }
                        else if(locacao.Filme.Lancamento == 1)
                        {
                            if ((locacao.DataDevolucao - locacao.DataLocacao).Days > 3)
                            {
                                retorno.Add(new RespostaClienteAtraso { Id = cliente.Id, Nome = cliente.Nome, Cpf = cliente.Cpf, DataNascimento = cliente.DataNascimento });
                            }
                        }
                    }
                }

                return Ok(retorno);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}
