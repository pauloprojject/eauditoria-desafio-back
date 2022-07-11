using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eaudit.Filtros
{
    public class AtualizarFilmeFiltro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public int Lancamento { get; set; }
    }
}
