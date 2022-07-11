using eaudit.data.Model;
using eaudit.data.Repositorio.Interfaces;
using eaudit.Filtros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eaudit.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IRepositorioCrud _repositorio;

        public ClienteController(IRepositorioCrud repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpPost("CadastrarCliente")]
        public IActionResult CadastrarCliente([FromBody] CadastrarClienteFiltro filtro)
        {
            try
            {
                Cliente cliente = new Cliente(filtro.Nome, filtro.Cpf, filtro.DataNascimento);

                _repositorio.CadastrarCliente(cliente);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("ConsultarCliente")]
        public IActionResult ConsultarCliente([FromQuery] int id)
        {
            try
            {
                Cliente cliente = _repositorio.ConsultarClientePorId(id);

                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("AtualizarCliente")]
        public IActionResult AtualizarCliente([FromBody] AtualizarClienteFiltro filtro)
        {
            try
            {

                Cliente cliente = _repositorio.ConsultarClientePorId(filtro.Id);

                cliente.Atualizar(filtro.Nome, filtro.Cpf, filtro.DataNascimento);

                _repositorio.AtualizarCliente(cliente);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeletarCliente")]
        public IActionResult DeletarCliente([FromQuery] int id)
        {
            try
            {
                _repositorio.DeletarClientePorId(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("TodosClientes")]
        public IActionResult TodosClientes()
        {
            try
            {
                var clientes = _repositorio.RetornarTodosClientes();

                return Ok(clientes);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
