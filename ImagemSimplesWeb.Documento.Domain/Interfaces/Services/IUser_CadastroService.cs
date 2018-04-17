using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Interfaces.Services
{
    public interface IUser_CadastroService
    {
        List<USER_CADASTRO> BuscarTodos();
        bool ValidarUsuario(USER_CADASTRO user);
        List<USER_MENU1> BuscarMenu();
        USER_CADASTRO RetornaUsuario(int id);
        void AlteraUsuario(USER_CADASTRO user);
    }
}
