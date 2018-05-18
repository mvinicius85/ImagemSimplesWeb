using ImagemSimplesWeb.Core.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Interfaces.Repository
{
    public interface IUser_PermissoesRepository : IRepository<user_permissoes>
    {
        List<DTOAcessos> RetornaAcessos(int id_user);
        int ExcluiAcessos(int id_user);
        List<user_modulos> RetornaModulos(int id);
    }
}
