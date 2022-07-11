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
    public class RepositorioCrud : RepositorioBase, IRepositorioCrud
    {
        private readonly EauditDbContext _contexto;

        public RepositorioCrud(EauditDbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public Cliente ConsultarClientePorId(int id)
        {
            return _contexto.Clientes
                .AsNoTracking()
                .Include(x => x.Locacoes)
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public Filme ConsultarFilmePorId(int id)
        {
            return _contexto.Filmes
                .AsNoTracking()
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public Locacao ConsultarLocacaoPorId(int id)
        {
            return _contexto.Locacaos
                .AsNoTracking()
                .Include(x => x.Filme)
                .Include(x => x.Cliente)
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public void CadastrarCliente(Cliente cliente)
        {
            Cadastrar<Cliente>(cliente);
            _contexto.SaveChanges();
        }

        public void CadastrarLocacao(Locacao locacao)
        {
            Cadastrar<Locacao>(locacao);
            _contexto.SaveChanges();
        }

        public void CadastrarFilme(Filme filme)
        {
            Cadastrar<Filme>(filme);
            _contexto.SaveChanges();
        }

        public void AtualizarCliente(Cliente cliente)
        {
            Atualizar<Cliente>(cliente);
            _contexto.SaveChanges();
        }

        public void AtualizarLocacao(Locacao locacao)
        {
            Atualizar<Locacao>(locacao);
            _contexto.SaveChanges();
        }

        public void AtualizarFilme(Filme filme)
        {
            Atualizar<Filme>(filme);
            _contexto.SaveChanges();
        }

        public void DeletarClientePorId(int id)
        {
            Apagar<Cliente>(ConsultarClientePorId(id));
            _contexto.SaveChanges();
        }

        public void DeletarFilmePorId(int id)
        {
            Apagar<Filme>(ConsultarFilmePorId(id));
            _contexto.SaveChanges();
        }

        public void DeletarLocacaoPorId(int id)
        {
            Apagar<Locacao>(ConsultarLocacaoPorId(id));
            _contexto.SaveChanges();
        }

        public IList<Cliente> RetornarTodosClientes()
        {
            return _contexto.Clientes
                .AsNoTracking()
                .ToList();
        }

        public IList<Filme> RetornarTodosFilmes()
        {
            return _contexto.Filmes
                .AsNoTracking()
                .ToList();
        }

        public IList<Locacao> RetornarTodasLocacoes()
        {
            return _contexto.Locacaos
                .AsNoTracking()
                .ToList();
        }
    }
}
