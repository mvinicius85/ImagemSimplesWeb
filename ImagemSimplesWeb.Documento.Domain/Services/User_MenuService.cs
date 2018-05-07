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
        private readonly IUser_Cat_AtributoRepository _atribrepository;
        public User_MenuService(IUser_MenuRepository menurepository, IUser_Cat_AtributoRepository atribrepository)
        {
            _menurepository = menurepository;
            _atribrepository = atribrepository;
        }

        public void AlteraCategoria(USER_MENU1 cat, List<USER_CAT_ATRIBUTOS> atrib)
        {
            int i = 1;
            var cat1 = _menurepository.ObterPorId(cat.id_Oper);
            cat1.Dependencia = cat.Dependencia;
            cat1.Descricao = cat.Descricao;
            cat1.Nivel = cat.Nivel;
            cat1.NOME = cat.NOME;
            cat1.ExisteMDB = cat.ExisteMDB;
            cat1.PATHIMAGENS = cat.PATHIMAGENS;
            _atribrepository.ExcluirAtributos(cat1.id_Oper);
            _menurepository.Atualizar(cat1);
            foreach (var item in atrib)
            {
                item.Ordem = i;
                _atribrepository.Adicionar(item);
                i = i + 1;
            }
        }

        public void AlteraCategoria(USER_MENU1 cat)
        {
            _menurepository.Adicionar(cat);
        }

        public USER_MENU1 BuscaCategoria(int id)
        {
            var cat = _menurepository.ObterPorId(id);
            //cat.Atributos = _atribrepository.Buscar(x => x.id_Oper == cat.id_Oper).ToList();
            return cat;
        }

        public void ExcluiAtributos(USER_MENU1 cat)
        {
            _atribrepository.ExcluirAtributos(cat.id_Oper);
        }

        public void InsereCategoria(USER_MENU1 cat, List<USER_CAT_ATRIBUTOS> atrib)
        {
            int i = 1;
            var cat2 = _menurepository.Adicionar(cat);
            foreach (var item in atrib)
            {
                item.Ordem = i;
                item.id_Oper = cat2.id_Oper;
                _atribrepository.Adicionar(item);
                i = i + 1;
            }
        }

        public List<USER_MENU1> ListaCategorias()
        {
            return _menurepository.ObterTodos().ToList();
        }

        public List<USER_CAT_ATRIBUTOS> RetornaAtributos(int id_Oper)
        {
            return _atribrepository.Buscar(x => x.id_Oper == id_Oper).ToList();
        }

        public List<USER_MENU1> RetornaCategorias(string desc)
        {
            return _menurepository.Buscar(x => x.Descricao.Contains(desc)).ToList();
        }
    }
}
