using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   ImagemSimplesWeb.Documento.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        int Commit();
        string[] GetPrimearyKey<T>(T obj);
        void DisposeContexto();
        void DisposeAdd();
    }
}
