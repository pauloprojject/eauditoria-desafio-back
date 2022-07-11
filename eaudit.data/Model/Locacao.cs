using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eaudit.data.Model
{
    public class Locacao
    {
        public Locacao(int clienteId, int filmeId, DateTime dataLocacao, DateTime dataDevolucao)
        {
            ClienteId = clienteId;
            FilmeId = filmeId;
            DataLocacao = dataLocacao;
            DataDevolucao = dataDevolucao;
        }

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int FilmeId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Filme Filme { get; set; }

        public void Atualizar(int filmeId, int clienteId, DateTime dataDevolucao, DateTime dataLocacao)
        {
            ClienteId = clienteId;
            FilmeId = filmeId;
            DataDevolucao = dataDevolucao;
            DataLocacao = dataLocacao;
        }
    }
}
