﻿using ImagemSimplesWeb.Application.ViewModels;
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
        string AlterarUsuario(User_CadastroViewModel usuario);
        List<USER_CAT_ATRIBUTOSViewModel> ListarAtributos(int id);
    }
}
