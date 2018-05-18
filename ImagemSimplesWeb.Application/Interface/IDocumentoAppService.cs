using ImagemSimplesWeb.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.Interface
{
    public interface IDocumentoAppService
    {
        string InsereDocumento(User_Documentos_ImagemViewModel doc);
    }
}
