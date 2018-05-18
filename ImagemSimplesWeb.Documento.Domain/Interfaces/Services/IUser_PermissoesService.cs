using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Interfaces.Services
{
    public interface IUser_PermissoesService
    {
        List<DTOAcessos> RetornaAcessos(int id_user);
        void AtualizarAcessos(int id_user, List<DTOAcessos> acessos);
        List<user_modulos> RetornaModulos(int id);
        void InserirModulos(List<user_modulos> list, int id_user);
        void AtualizarModulos(int id_user, List<user_modulos> list);
    }
}
