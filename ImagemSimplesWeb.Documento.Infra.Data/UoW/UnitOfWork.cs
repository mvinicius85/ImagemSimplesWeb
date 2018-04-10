using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using ImagemSimplesWeb.Documento.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Imagem_ItapeviContext _context;
        private bool _disposed;

        public UnitOfWork(Imagem_ItapeviContext context)
        {
            _context = context;            
        }

        public void BeginTransaction()
        {
            _disposed = false;
            //DetachAllEntities();
        }


        private void DetachAllEntities()
        {
      

            var result = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)_context).ObjectContext;

             var objs=    result.ObjectStateManager.GetObjectStateEntries(EntityState.Unchanged);

            foreach (var entity in objs)
            {
                _context.Entry(entity.Entity).State =EntityState.Detached;
            }
        }

        private void DetachAlt()
        {
            var result = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)_context).ObjectContext;

            var objs = result.ObjectStateManager.GetObjectStateEntries(EntityState.Modified);

            foreach (var entity in objs)
            {
                _context.Entry(entity.Entity).State = EntityState.Detached;
            }
        }

        public void DisposeContexto()
        {
            DetachAllEntities();
        }
        public void DisposeAdd()
        {
            DetachAdd();
        }

        private void DetachAdd()
        {
            var result = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)_context).ObjectContext;

            var objs = result.ObjectStateManager.GetObjectStateEntries(EntityState.Added);

            foreach (var entity in objs)
            {
                _context.Entry(entity.Entity).State = EntityState.Detached;
            }
        }

        public int Commit()
        {
                        
           return  _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void DisposeAll()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string[] GetPrimearyKey<T>(T obj)
        {
            System.Data.Entity.Core.Objects.ObjectStateEntry objectStateManager;

            ((IObjectContextAdapter)_context).ObjectContext.ObjectStateManager.TryGetObjectStateEntry(obj, out objectStateManager);

            if (objectStateManager == null)
                return null;


            System.Data.Entity.Core.Metadata.Edm.EntitySetBase setBase = objectStateManager.EntitySet;

            string[] keyNames = setBase.ElementType.KeyMembers.Select(k => k.Name).ToArray();

            return keyNames;
        }
    }
}
