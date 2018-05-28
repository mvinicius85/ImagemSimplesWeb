using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Interfaces.Services
{
    public interface IUser_MenuService
    {
        List<user_menu1> ListaCategorias();
        user_menu1 BuscaCategoria(int id);
        void AlteraCategoria(user_menu1 cat, List<user_cat_atributos> atrib);
        void ExcluiAtributos(user_menu1 cat);
        List<user_cat_atributos> RetornaAtributos(int id_Oper);
        List<user_menu1> RetornaCategorias(DTOCategorias filtro);
        void InsereCategoria(user_menu1 cat, List<user_cat_atributos> atrib);
        List<user_menu1> CategoriasDocumento();
        List<user_tipo_arquivo> ListaTiposArquivo();
        string VerificaDocumentosVinculados(int id_Oper);
        string ValidaCategoria(user_menu1 user_menu1);
    }
}
