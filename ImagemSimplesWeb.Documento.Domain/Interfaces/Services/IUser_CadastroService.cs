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
        List<user_cadastro> BuscarTodos();
        bool ValidarUsuario(user_cadastro user);
        List<user_menu1> BuscarMenu();
        user_cadastro RetornaUsuario(int id);
        user_cadastro RetornaUsuario(string login);
        void AlteraUsuario(user_cadastro user);
        void InserirUsuario(user_cadastro usuario);
        List<user_cadastro> FiltrarUsuarios(user_cadastro filtro);
    }
}
