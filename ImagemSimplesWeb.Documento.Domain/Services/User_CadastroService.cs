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

        public void AlteraUsuario(USER_CADASTRO user)
        {
            var user1 = _cadastrorepository.ObterPorId(user.id_user);
            user1.codigo = user.codigo.TrimEnd().TrimStart();
            user1.Senha = user.Senha.TrimEnd().TrimStart();
            user1.Nome = user.Nome.TrimEnd().TrimStart();
            user1.Depto = user.Depto.TrimEnd().TrimStart();
            user1.Assinatura = user.Assinatura.TrimEnd().TrimStart();
            user1.ativo = user.ativo;
            user1.Data = user.Data.TrimEnd().TrimStart();
            user1.DataInicio = user.DataInicio.TrimEnd().TrimStart();
            user1.Email = user.Email.TrimEnd().TrimStart();
            user1.LiberaRequisicao = user.LiberaRequisicao;
            user1.nomepc = user.nomepc.TrimEnd().TrimStart();
            user1.secao = user.secao.TrimEnd().TrimStart();
            user1.Tel1 = user.Tel1.TrimEnd().TrimStart();
            user1.Tel2 = user.Tel2.TrimEnd().TrimStart();
            user1.Tel3 = user.Tel3.TrimEnd().TrimStart();
            _cadastrorepository.Atualizar(user1);
        }

        public List<USER_MENU1> BuscarMenu()
        {
            return _menurepository.ObterTodos().ToList();
        }

        public List<USER_CADASTRO> BuscarTodos()
        {
            return _cadastrorepository.ObterTodos().ToList();
        }

        public USER_CADASTRO RetornaUsuario(int id)
        {
            return _cadastrorepository.ObterPorId(id);
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
