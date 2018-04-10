using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Core.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity>  where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(int id);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity obj);
        void Remover(int id);
        void Remover(TEntity obj);
        void Remover(List<TEntity> list);
        void Remover(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges(); 
        bool Existe(Expression<Func<TEntity, bool>> predicate);
        TEntity ObterPorId(string id);
        IEnumerable<TEntity> RetornaMdb(string path);
    }
}
