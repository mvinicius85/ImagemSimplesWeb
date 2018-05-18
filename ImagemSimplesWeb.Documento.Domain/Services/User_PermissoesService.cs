using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Entities.DTO;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Services
{
    public class User_PermissoesService : IUser_PermissoesService
    {
        private readonly IUser_PermissoesRepository _permissoesrepository;
        private readonly IUser_Cadastro_ModulosRepository _cadmodulosrepository;
        public User_PermissoesService(IUser_PermissoesRepository permissoesrepository, IUser_Cadastro_ModulosRepository cadmodulosrepository)
        {
            _permissoesrepository = permissoesrepository;
            _cadmodulosrepository = cadmodulosrepository;
        }

        public void AtualizarAcessos(int id_user, List<DTOAcessos> acessos)
        {
            _permissoesrepository.ExcluiAcessos(id_user);
            foreach (var item in acessos)
            {
                var acesso = new user_permissoes(id_user.ToString(), item.id_oper, item.Nivel + " - " + item.Descricao, true);
                _permissoesrepository.Adicionar(acesso);
            }
        }

        public void AtualizarModulos(int id_user, List<user_modulos> list)
        {
            _cadmodulosrepository.ExcluirModulos(id_user);
            foreach (var item in list)
            {
                _cadmodulosrepository.Adicionar(new user_cadastro_modulos(id_user, item.id_modulo));
            }
        }

        public void InserirModulos(List<user_modulos> list, int id_user)
        {
            foreach (var item in list)
            {
                _cadmodulosrepository.Adicionar(new user_cadastro_modulos(id_user,item.id_modulo));
            }

        }

        public List<DTOAcessos> RetornaAcessos(int id_user)
        {
            return _permissoesrepository.RetornaAcessos(id_user);
        }

        public List<user_modulos> RetornaModulos(int id)
        {
            return _permissoesrepository.RetornaModulos(id);
        }
    }
}
