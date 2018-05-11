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
                var acesso = new USER_PERMISSOES(id_user.ToString(), item.id_oper, item.Nivel + " - " + item.Descricao, true);
                _permissoesrepository.Adicionar(acesso);
            }
        }

        public void AtualizarModulos(int id_user, List<USER_MODULOS> list)
        {
            _cadmodulosrepository.ExcluirModulos(id_user);
            foreach (var item in list)
            {
                _cadmodulosrepository.Adicionar(new USER_CADASTRO_MODULOS(id_user, item.id_modulo));
            }
        }

        public void InserirModulos(List<USER_MODULOS> list, int id_user)
        {
            foreach (var item in list)
            {
                _cadmodulosrepository.Adicionar(new USER_CADASTRO_MODULOS(id_user,item.id_modulo));
            }

        }

        public List<DTOAcessos> RetornaAcessos(int id_user)
        {
            return _permissoesrepository.RetornaAcessos(id_user);
        }

        public List<USER_MODULOS> RetornaModulos(int id)
        {
            return _permissoesrepository.RetornaModulos(id);
        }
    }
}
