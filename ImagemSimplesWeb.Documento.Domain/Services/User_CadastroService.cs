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
    public class User_CadastroService : IUser_CadastroService
    {
        private readonly IUser_CadastroRepository _cadastrorepository;
        private readonly IUser_MenuRepository _menurepository;

        public User_CadastroService(IUser_CadastroRepository cadastrorepository,
            IUser_MenuRepository menurepository)
        {
            _cadastrorepository = cadastrorepository;
            _menurepository = menurepository;
        }

        public List<USER_MENU1> BuscarMenu()
        {
            return _menurepository.ObterTodos().ToList();
        }

        public List<USER_CADASTRO> BuscarTodos()
        {
            return _cadastrorepository.ObterTodos().ToList();
        }

        public bool ValidarUsuario(USER_CADASTRO user)
        {
            if (!_cadastrorepository.Buscar(x => x.Nome == user.Nome).Any())
            { return false; }
            if (!_cadastrorepository.Buscar(x => x.Nome == user.Nome && x.Senha == user.Senha).Any())
            {
                return false;
            }
            return true;
        }
    }
}
