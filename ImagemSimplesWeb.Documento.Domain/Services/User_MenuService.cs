using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Services
{
    public class User_MenuService : IUser_MenuService
    {
        private readonly IUser_MenuRepository _menurepository;
        public User_MenuService(IUser_MenuRepository menurepository)
        {
            _menurepository = menurepository;
        }

        public void AlteraCategoria(USER_MENU1 cat)
        {
            var cat1 = _menurepository.ObterPorId(cat.id_Oper);
            cat1.Dependencia = cat.Dependencia;
            cat1.Descricao = cat.Descricao;
            cat1.ExisteMDB = cat.ExisteMDB;
            cat1.PATHIMAGENS = cat.PATHIMAGENS;
            _menurepository.Atualizar(cat1);
        }

        public USER_MENU1 BuscaCategoria(int id)
        {
            return _menurepository.ObterPorId(id);
        }

        public List<USER_MENU1> ListaCategorias()
        {
            return _menurepository.ObterTodos().ToList();
        }
    }
}
