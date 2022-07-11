using eaudit.data.Data;
using eaudit.data.Model;
using eaudit.data.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eaudit.data.Repositorio
{
    public class RepositorioRelatorios : RepositorioBase, IRepositorioRelatorios
    {
        private readonly EauditDbContext _contexto;

        public RepositorioRelatorios(EauditDbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public IList<Cliente> ClientesAtraso()
        {
            return _contexto.Clientes
                .Include(x => x.Locacoes)
                .ThenInclude(x => x.Filme)
                .Where(x => x.Locacoes.Any())
                .ToList();
        }

        public IList<Filme> CincoFilmesMaisAlugadosNoAno()
        {
            return _contexto.Filmes
                .Where(x => x.Locacoes.Any() && x.Locacoes.Any(y => y.DataLocacao > DateTime.Now.AddYears(-1)))
                .OrderByDescending(x => x.Locacoes.Count)
                .ToList();
        }

        public IList<Filme> FilmesSemLocacoes()
        {
            return _contexto.Filmes
                .Where(x => !x.Locacoes.Any())
                .ToList();
        }

        public Cliente SegundoClienteMaisLocacoes()
        {
            return _contexto.Clientes
                .Where(x => x.Locacoes.Any())
                .OrderByDescending(x => x.Locacoes.Count)
                .ToList()[1];
        }

        public IList<Filme> TresFilmesMenosAlugados()
        {
            return _contexto.Filmes
                .Where(x => x.Locacoes.Any() && x.Locacoes.Any(y => y.DataLocacao > DateTime.Now.AddDays(-7)))
                .OrderBy(x => x.Locacoes.Count)
                .Take(3)
                .ToList();
        }
    }
}
