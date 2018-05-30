using AutoMapper;
using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Application.ViewModels;
using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Entities.DTO;
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
        private readonly IUser_PermissoesService _permissoesservice;
        public CadastroAppService(IUser_CadastroService cadastroservice, IUser_MenuService menuservice,
            IUser_PermissoesService permissoesservice,
             Documento.Infra.Data.Interfaces.IUnitOfWork uow) : base(uow)
        {
            _cadastroservice = cadastroservice;
            _menuservice = menuservice;
            _permissoesservice = permissoesservice;
        }

        public string AlteraCategoria(User_MenuViewModel cat)
        {
            try
            {
                //var msg = _menuservice.ValidaCategoria(cat.id_Oper);
                //if (!String.IsNullOrEmpty(msg))
                //{
                //    return msg;
                //}
                BeginDocumentoTransaction();
                var ret = _menuservice.ValidaCategoria(Mapper.Map<user_menu1>(cat));
                if (!String.IsNullOrEmpty(ret)) 
                {
                    return ret;
                }
                _menuservice.AlteraCategoria(Mapper.Map<user_menu1>(cat), Mapper.Map<List<user_cat_atributos>>(cat.Atributos));
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
            try
            {
                BeginDocumentoTransaction();
                _cadastroservice.AlteraUsuario(Mapper.Map<user_cadastro>(usuario));
                _permissoesservice.AtualizarAcessos(usuario.id_user, Mapper.Map<List<DTOAcessos>>(usuario.Acessos));
                _permissoesservice.AtualizarModulos(usuario.id_user, Mapper.Map<List<user_modulos>>(usuario.Modulos));
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

        public List<User_MenuViewModel> BuscarCategoria(frmCategoriasViewModel categoria)
        {
            var ret = Mapper.Map<List<User_MenuViewModel>>(_menuservice.RetornaCategorias(Mapper.Map<DTOCategorias>(categoria)));
            return ret.OrderBy(x => x.id_Oper).ToList();
        }

        public List<User_MenuViewModel> CategoriasDocumentos()
        {
            var categorias = Mapper.Map<List<User_MenuViewModel>>(_menuservice.CategoriasDocumento().Where(x => x.id_tipo_arquivo == 3).ToList());
            categorias.Add(new User_MenuViewModel(0, ""));
            return categorias.OrderBy(x => x.id_Oper).ToList();
        }

        public List<User_CadastroViewModel> FiltrarUsuarios(User_CadastroViewModel filtro)
        {
            var usuarios = Mapper.Map<List<User_CadastroViewModel>>(_cadastroservice.FiltrarUsuarios(Mapper.Map<user_cadastro>(filtro)));
            return usuarios;
        }

        public string InserirCategoria(User_MenuViewModel cat)
        {
            try
            {
                BeginDocumentoTransaction();
                var ret =_menuservice.InsereCategoria(Mapper.Map<user_menu1>(cat), Mapper.Map<List<user_cat_atributos>>(cat.Atributos));
                if (ret > 0)
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

        public string InserirUsuario(User_CadastroViewModel usuario)
        {
            try
            {
                BeginDocumentoTransaction();
                _cadastroservice.InserirUsuario(Mapper.Map<user_cadastro>(usuario));
                _permissoesservice.InserirModulos(Mapper.Map<List<user_modulos>>(usuario.Modulos), usuario.id_user);
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

        public List<User_CadastroViewModel> ListaCadastro()
        {
            var teste = Mapper.Map<List<User_CadastroViewModel>>(_cadastroservice.BuscarTodos());
            return teste;
        }

        public List<User_MenuViewModel> ListaCategorias()
        {
            return Mapper.Map<List<User_MenuViewModel>>(_menuservice.ListaCategorias().OrderBy(x => x.id_oper).ToList());
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
            var str = _menuservice.VerificaDocumentosVinculados(cat.id_Oper);
            if (!String.IsNullOrEmpty(str))
            {
                cat.PossuiDocumentos = true;
            }
            return cat;
        }

        public frmCadCategoriaViewModel PreencheTela()
        {
            var form = new frmCadCategoriaViewModel();
            form.Menus = Mapper.Map<List<User_MenuViewModel>>(_menuservice.ListaCategorias());
            form.TiposArquivo = Mapper.Map<List<User_Tipo_ArquivoViewModel>>(_menuservice.ListaTiposArquivo());
            form.Menus.Add(new User_MenuViewModel(0, ""));
            form.TiposArquivo.Add(new User_Tipo_ArquivoViewModel(0, ""));
            return form;
        }

        public string RetornaCaminhoImgens(int idoper)
        {
            var menuitem = _menuservice.BuscaCategoria(idoper);
            return menuitem.pathimagens;
        }

        public User_CadastroViewModel RetornaUsuario(int id)
        {
            var usuario = Mapper.Map<User_CadastroViewModel>(_cadastroservice.RetornaUsuario(id));
            usuario.Acessos = Mapper.Map<List<AcessosViewModel>>(_permissoesservice.RetornaAcessos(id));
            usuario.Modulos = Mapper.Map<List<User_ModulosViewModel>>(_permissoesservice.RetornaModulos(id));
            return usuario;
        }

        public User_CadastroViewModel RetornaUsuario(string login)
        {
            var usuario = Mapper.Map<User_CadastroViewModel>(_cadastroservice.RetornaUsuario(login));
            usuario.Acessos = Mapper.Map<List<AcessosViewModel>>(_permissoesservice.RetornaAcessos(usuario.id_user));
            usuario.Modulos = Mapper.Map<List<User_ModulosViewModel>>(_permissoesservice.RetornaModulos(usuario.id_user));
            return usuario;
        }

        public bool ValidaCategoria(string codcategoria)
        {
            var categoria = Mapper.Map<User_MenuViewModel>(_menuservice.BuscaCategoria(Convert.ToInt32(codcategoria)));
            if (categoria.Dependencia == 0)
            {
                return true;
            }
            var subcategoria = Mapper.Map<User_MenuViewModel>(_menuservice.BuscaCategoria(Convert.ToInt32(categoria.Dependencia)));
            if (subcategoria.Dependencia == 0)
            {
                return true;
            }
            return false;
        }

        public bool ValidaLogin(string user, string senha)
        {
            var usuario = new user_cadastro(user, senha);
            return _cadastroservice.ValidarUsuario(usuario);
        }
    }
}
