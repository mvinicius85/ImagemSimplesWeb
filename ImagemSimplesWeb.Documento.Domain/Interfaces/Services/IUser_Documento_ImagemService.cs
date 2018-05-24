using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImagemSimplesWeb.Documento.Domain.Entities.Documento;

namespace ImagemSimplesWeb.Documento.Domain.Interfaces.Services
{
    public interface IUser_Documento_ImagemService
    {
        user_documentos_imagem AdicionaDocumento(user_documentos_imagem doc);
        void AdicionarAtributo(user_documentos_atributos user_documentos_atributos);
        DataTable PesquisaDocumentos(int idoper, string query);
    }
}
