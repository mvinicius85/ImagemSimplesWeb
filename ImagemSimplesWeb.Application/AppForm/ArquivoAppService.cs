using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.AppForm
{
    public class ArquivoAppService : IArquivoAppService
    {
        private readonly IMdbFileService _mdbservice;

        public ArquivoAppService(IMdbFileService mdbservice)
        {
            _mdbservice = mdbservice;
        }
        public DataTable AbreArquivo(string path)
        {
            var dt = _mdbservice.RetornaArquivo(path);
            return dt;
        }

        public void UpdatePath(string file)
        {
            try
            {
                if (ValidaMDB(file))
                {
                    _mdbservice.AlterarArquivo(file);
                }
                _mdbservice.UpdatePath(file);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool ValidaMDB(string fullName)
        {
            var dt = _mdbservice.RetornaArquivo(fullName);
            if (dt.Columns["path_documento"] == null)
            {
                return true;
            }
            return false;
        }
    }
}
