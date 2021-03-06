﻿using ImagemSimplesWeb.Core.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Interfaces.Repository
{
    public interface IUser_Documento_ImagemRepository : IRepository<user_documentos_imagem>
    {
        DataTable BuscarDocumentos(int idoper, string query);
        List<DTODocAtributos> BuscarAtributos(int iddoc);
    }
}
