using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.Interface
{
    public interface IArquivoAppService
    {
        DataTable AbreArquivo(string path, string query);
        bool ValidaMDB(string fullName);
        void UpdatePath(string file);
    }
}
