﻿using ImagemSimplesWeb.Core.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Interfaces.Repository
{
    public interface IUser_MenuRepository : IRepository<user_menu1>
    {
        List<user_menu1> CategoriasDocumento();
    }
}
