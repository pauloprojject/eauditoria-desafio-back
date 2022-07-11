using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eaudit.data.Model
{
    public class Filme
    {
        public Filme(string titulo, int classificacaoIndicativa, int lancamento)
        {
            Titulo = titulo;
            ClassificacaoIndicativa = classificacaoIndicativa;
            Lancamento = lancamento;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public int Lancamento { get; set; }
        public virtual ICollection<Locacao> Locacoes { get; set; }

        public void Atualizar(string titulo, int classificacaoIndicativa, int lancamento)
        {
            Titulo = titulo;
            ClassificacaoIndicativa = classificacaoIndicativa;
            Lancamento = lancamento;
        }
    }
}
