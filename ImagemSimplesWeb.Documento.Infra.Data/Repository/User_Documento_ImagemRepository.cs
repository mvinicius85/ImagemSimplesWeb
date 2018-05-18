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
    public class User_Documento_ImagemRepository : Repository<user_documentos_imagem>, IUser_Documento_ImagemRepository
    {
        public User_Documento_ImagemRepository(Imagem_ItapeviContext context) : base(context)
        {

        }
    }
}
