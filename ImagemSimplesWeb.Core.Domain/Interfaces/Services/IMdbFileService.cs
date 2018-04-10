using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Core.Domain.Interfaces.Services
{
    public interface IMdbFileService
    {
        DataTable RetornaArquivo(string path);
        void AlterarArquivo(string fullName);

        void UpdatePath(string fullName);
    }
}
