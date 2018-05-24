using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Infra.Data.Repository
{
    public class User_Tipo_ArquivoRepository : Repository<user_tipo_arquivo>, IUser_Tipo_ArquivoRepository
    {
        public User_Tipo_ArquivoRepository(Imagem_ItapeviContext context) : base(context)
        {

        }

    }
}
