using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application
{
    public class ApplicationService
    {
        private readonly Documento.Infra.Data.Interfaces.IUnitOfWork _uowDocumento;

        private bool beginStartDocumento;

        public ApplicationService(Documento.Infra.Data.Interfaces.IUnitOfWork uowDocumento)
        {
            _uowDocumento = uowDocumento;
        }


        public void BeginDocumentoTransaction()
        {
            if (_uowDocumento != null)
            {
                _uowDocumento.BeginTransaction();
                beginStartDocumento = true;
            }
        }

        public int CommitDocumento()
        {
            if (beginStartDocumento)
            {
                beginStartDocumento = false;
                return _uowDocumento.Commit();
            }
            else
                throw new System.ArgumentException("Transação do Documento não foi iniciada!");
        }




        public void BeginAllTransaction()
        {

            BeginDocumentoTransaction();
            // 
        }

        public int CommitAll()
        {

            int commit = 0;

            if (_uowDocumento != null)
                commit += CommitDocumento();

            return commit;
        }

        public void DisposeContexto()
        {

            _uowDocumento.DisposeContexto();

        }

        public void DisposeContextoAsync()
        {
            Task.Run(() => _uowDocumento.DisposeContexto());
        }

        public void DisposeAlt()
        {
            _uowDocumento.DisposeAdd();
        }
        public void DisposeAdd()
        {
            _uowDocumento.DisposeAdd();
        }
    }
}
