﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eaudit.Filtros
{
    public class AtualizarLocacaoFiltro
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int FilmeId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
