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

        public void AlteraUsuario(user_cadastro user)
        {
            var user1 = _cadastrorepository.ObterPorId(user.id_user);
            user1.codigo = user.codigo?.TrimEnd().TrimStart();
            user1.senha = user.senha?.TrimEnd().TrimStart();
            user1.nome = user.nome?.TrimEnd().TrimStart();
            user1.depto = user.depto?.TrimEnd().TrimStart();
            user1.assinatura = user.assinatura?.TrimEnd().TrimStart();
            user1.ativo = user.ativo;
            user1.data = user.data?.TrimEnd().TrimStart();
            user1.datainicio = user.datainicio?.TrimEnd().TrimStart();
            user1.email = user.email?.TrimEnd().TrimStart();
            user1.liberarequisicao = user.liberarequisicao;
            user1.nomepc = user.nomepc?.TrimEnd().TrimStart();
            user1.secao = user.secao?.TrimEnd().TrimStart();
            user1.tel1 = user.tel1?.TrimEnd().TrimStart();
            user1.tel2 = user.tel2?.TrimEnd().TrimStart();
            user1.tel3 = user.tel3?.TrimEnd().TrimStart();
            _cadastrorepository.Atualizar(user1);
        }

        public List<user_menu1> BuscarMenu()
        {
            return _menurepository.ObterTodos().ToList();
        }

        public List<user_cadastro> BuscarTodos()
        {
            return _cadastrorepository.ObterTodos().ToList();
        }

        public List<user_cadastro> FiltrarUsuarios(user_cadastro filtro)
        {
            return _cadastrorepository.FiltrarUsuarios(filtro);
        }

        public void InserirUsuario(user_cadastro usuario)
        {
            _cadastrorepository.Adicionar(usuario);
        }

        public user_cadastro RetornaUsuario(int id)
        {
            return _cadastrorepository.ObterPorId(id);
        }

        public user_cadastro RetornaUsuario(string login)
        {
            return _cadastrorepository.Buscar(x => x.nome.ToUpper() == login.ToUpper()).FirstOrDefault();
        }

        public bool ValidarUsuario(user_cadastro user)
        {
            if (!_cadastrorepository.Buscar(x => x.nome.ToUpper() == user.nome.ToUpper()).Any())
            { return false; }
            if (!_cadastrorepository.Buscar(x => x.nome.ToUpper() == user.nome.ToUpper() && x.senha == user.senha).Any())
            {
                return false;
            }
            var usuario = _cadastrorepository.Buscar(x => x.nome.ToUpper() == user.nome.ToUpper() && x.senha == user.senha).FirstOrDefault();
            if (!usuario.ativo)
            {
                return false;
            }
            return true;
        }
    }
}
