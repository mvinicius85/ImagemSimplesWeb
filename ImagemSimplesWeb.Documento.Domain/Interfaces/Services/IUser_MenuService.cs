using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Interfaces.Services
{
    public interface IUser_MenuService
    {
        List<USER_MENU1> ListaCategorias();
        USER_MENU1 BuscaCategoria(int id);
        void AlteraCategoria(USER_MENU1 cat, List<USER_CAT_ATRIBUTOS> atrib);
        void ExcluiAtributos(USER_MENU1 cat);
        List<USER_CAT_ATRIBUTOS> RetornaAtributos(int id_Oper);
        List<USER_MENU1> RetornaCategorias(string desc);
        void InsereCategoria(USER_MENU1 cat, List<USER_CAT_ATRIBUTOS> atrib);
    }
}
