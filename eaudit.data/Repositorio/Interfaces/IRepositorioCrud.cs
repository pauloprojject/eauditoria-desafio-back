using eaudit.data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eaudit.data.Repositorio.Interfaces
{
    public interface IRepositorioCrud
    {
        Filme ConsultarFilmePorId(int id);
        Locacao ConsultarLocacaoPorId(int id);
        Cliente ConsultarClientePorId(int id);
        void CadastrarCliente(Cliente cliente);
        void CadastrarLocacao(Locacao locacao);
        void CadastrarFilme(Filme filme);
        void AtualizarCliente(Cliente cliente);
        void AtualizarLocacao(Locacao locacao);
        void AtualizarFilme(Filme filme);
        void DeletarClientePorId(int id);
        void DeletarFilmePorId(int id);
        void DeletarLocacaoPorId(int id);
        IList<Cliente> RetornarTodosClientes();
        IList<Filme> RetornarTodosFilmes();
        IList<Locacao> RetornarTodasLocacoes();
    }
}
