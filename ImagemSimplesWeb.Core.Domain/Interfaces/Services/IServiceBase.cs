using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace ImagemSimplesWeb.Core.Domain.Interfaces.Service
{
    public interface IServiceBase<TEntity> where TEntity : class
    {

        void Adicionar(TEntity obj);       
        TEntity ObterPorId(int id);
        TEntity ObterPorId(string id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity obj);
        void Remover(TEntity obj);
        void Remover(int id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);


    }
}
