using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento

{
    public partial class user_cadastro_modulos
    {
        public user_cadastro_modulos()
        {

        }

        public user_cadastro_modulos( int _iduser, int _idmod)
        {
            id_user = _iduser;
            id_modulo = _idmod;
        }
        public int id_cadastro_modulo { get; set; }
        public int id_user { get; set; }
        public int id_modulo { get; set; }
    }
}
