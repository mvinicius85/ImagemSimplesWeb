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
    }
}
