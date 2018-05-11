using ImagemSimplesWeb.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.Interface
{
    public interface ICadastroAppService
    {
        List<User_CadastroViewModel> ListaCadastro();
        bool ValidaLogin(string user, string senha);
        List<User_MenuViewModel> BuscaMenu();
        List<User_MenuViewModel> ListaCategorias();
        frmCadCategoriaViewModel PreencheTela();
        User_MenuViewModel PesquisaCategoria(int id);
        string AlteraCategoria(User_MenuViewModel cat);
        string RetornaCaminhoImgens(int idoper);
        List<User_CadastroViewModel> ListaUsuarios();
        User_CadastroViewModel RetornaUsuario(int id);
        User_CadastroViewModel RetornaUsuario(string login);
        string AlterarUsuario(User_CadastroViewModel usuario);
        List<USER_CAT_ATRIBUTOSViewModel> ListarAtributos(int id);
        List<User_MenuViewModel> BuscarCategoria(string desc);
        string InserirCategoria(User_MenuViewModel cat);
        string InserirUsuario(User_CadastroViewModel usuario);
        List<User_CadastroViewModel> FiltrarUsuarios(User_CadastroViewModel filtro);
        bool ValidaCategoria(string codcategoria);

    }
}
