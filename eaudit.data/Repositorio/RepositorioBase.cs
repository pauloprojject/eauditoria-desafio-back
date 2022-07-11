using eaudit.data.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eaudit.data.Repositorio
{
    public class RepositorioBase : IRepositorioBase
    {
        protected DbContext Contexto { get; private set; }

        public RepositorioBase(DbContext contexto)
        {
            Contexto = contexto;
        }

        public void Cadastrar<T>(T model) where T : class
        {
            Contexto.Set<T>().Add(model);
        }

        public void Atualizar<T>(T model) where T : class
        {
            Contexto.Set<T>().Update(model);
        }

        public void Apagar<T>(T model) where T : class
        {
            Contexto.Set<T>().Remove(model);
        }
    }
}
