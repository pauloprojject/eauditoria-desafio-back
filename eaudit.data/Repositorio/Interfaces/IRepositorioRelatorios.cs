using eaudit.data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eaudit.data.Repositorio.Interfaces
{
    public interface IRepositorioRelatorios
    {
        IList<Cliente> ClientesAtraso();
        Cliente SegundoClienteMaisLocacoes();
        IList<Filme> FilmesSemLocacoes();
        IList<Filme> CincoFilmesMaisAlugadosNoAno();
        IList<Filme> TresFilmesMenosAlugados();
    }
}
