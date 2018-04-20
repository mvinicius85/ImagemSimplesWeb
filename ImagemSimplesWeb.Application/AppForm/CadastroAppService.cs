using AutoMapper;
using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Application.ViewModels;
using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImagemSimplesWeb.Application.AppForm
{

    public class CadastroAppService : ApplicationService, ICadastroAppService
    {
        private readonly IUser_CadastroService _cadastroservice;
        private readonly IUser_MenuService _menuservice;
        public CadastroAppService(IUser_CadastroService cadastroservice, IUser_MenuService menuservice,
             Documento.Infra.Data.Interfaces.IUnitOfWork uow) : base(uow)
        {
            _cadastroservice = cadastroservice;
            _menuservice = menuservice;
        }

        public string AlteraCategoria(User_MenuViewModel cat)
        {
            try
            {
                BeginDocumentoTransaction();
                _menuservice.AlteraCategoria(Mapper.Map<USER_MENU1>(cat), Mapper.Map<List<USER_CAT_ATRIBUTOS>>(cat.Atributos));
                if (CommitDocumento() > 0)
                {
                    return "S";
                }
                return "N";

            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }


        }

        public string AlterarUsuario(User_CadastroViewModel usuario)
        {
            BeginDocumentoTransaction();
            _cadastroservice.AlteraUsuario(Mapper.Map<USER_CADASTRO>(usuario));
            if (CommitDocumento() > 0)
            {
                return "S";
            }
            return "N";
        }

        public List<User_MenuViewModel> BuscaMenu()
        {
            var menu = Mapper.Map<List<User_MenuViewModel>>(_cadastroservice.BuscarMenu());
            foreach (var item in menu)
            {
                if (!String.IsNullOrEmpty(item.PATHIMAGENS))
                {
                    item.PATHIMAGENS = item.PATHIMAGENS.Replace(@"\", @"\\");
                }
                if (item.Dependencia > 0)
                {
                    menu.Where(y => y.id_Oper == item.Dependencia).FirstOrDefault().submenu.Add(item);
                }
            }
            var final = menu.Where(x => x.Dependencia == 0).OrderBy(y => y.id_Oper).ToList();
            return final;
        }

        public List<User_CadastroViewModel> ListaCadastro()
        {
            var teste = Mapper.Map<List<User_CadastroViewModel>>(_cadastroservice.BuscarTodos());
            return teste;
        }

        public List<User_MenuViewModel> ListaCategorias()
        {
            return Mapper.Map<List<User_MenuViewModel>>(_menuservice.ListaCategorias());
        }

        public List<USER_CAT_ATRIBUTOSViewModel> ListarAtributos(int id)
        {
            return Mapper.Map<List<USER_CAT_ATRIBUTOSViewModel>>(_menuservice.RetornaAtributos(id));
        }

        public List<User_CadastroViewModel> ListaUsuarios()
        {
            var usuarios = Mapper.Map<List<User_CadastroViewModel>>(_cadastroservice.BuscarTodos());
            return usuarios;
        }

        public User_MenuViewModel PesquisaCategoria(int id)
        {
            var cat = Mapper.Map<User_MenuViewModel>(_menuservice.BuscaCategoria(id));
            cat.Atributos = Mapper.Map<List<USER_CAT_ATRIBUTOSViewModel>>(_menuservice.RetornaAtributos(cat.id_Oper));
            return cat;
        }

        public frmCadCategoriaViewModel PreencheTela()
        {
            var form = new frmCadCategoriaViewModel();
            form.Menus = Mapper.Map<List<User_MenuViewModel>>(_menuservice.ListaCategorias());
            return form;
        }

        public string RetornaCaminhoImgens(int idoper)
        {
            var menuitem = _menuservice.BuscaCategoria(idoper);
            return menuitem.PATHIMAGENS;
        }

        public User_CadastroViewModel RetornaUsuario(int id)
        {
            var usuario = Mapper.Map<User_CadastroViewModel>(_cadastroservice.RetornaUsuario(id));
            return usuario;
        }

        public bool ValidaLogin(string user, string senha)
        {
            var usuario = new USER_CADASTRO(user, senha);
            return _cadastroservice.ValidarUsuario(usuario);
        }
    }
}
