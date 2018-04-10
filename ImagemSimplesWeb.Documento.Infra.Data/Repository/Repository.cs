using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using ImagemSimplesWeb.Core.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using ImagemSimplesWeb.Core.Infra.Data.Contexto;

namespace ImagemSimplesWeb.Documento.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected Imagem_ItapeviContext Db;
        protected DbSet<TEntity> DbSet;
        protected ArquivoMdbContext MdbDb;

        public Repository(Imagem_ItapeviContext context)
        {
            Db = context;

            DbSet = null;
            DbSet = Db.Set<TEntity>();
        }

        public Repository(ArquivoMdbContext context)
        {
            MdbDb = context;

            DbSet = null;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
           
            return objreturn;
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()//(int s, int t)
        {
            return DbSet.AsNoTracking().ToList(); //Take(t).Skip(s).ToList();
        }



        public virtual TEntity Atualizar(TEntity obj)
        {

            var entry = Db.Entry(obj);

            entry.State = EntityState.Modified;
            
            return obj;
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }


        public int SaveChanges()
        {
            return Db.SaveChanges();
        }



        public TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public void Remover(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Remover(TEntity obj)
        {


            var entry = Db.Entry(obj);

            entry.State = EntityState.Deleted;

           // DbSet.Remove(obj);
        }

        public bool Existe(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public void Remover(List<TEntity> list)
        {

            DbSet.RemoveRange(list);
        }

        public TEntity ObterPorId(string id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> RetornaMdb(string path)
        {
            return DbSet.AsNoTracking().ToList();
        }
    }
}
