using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento

{
    public partial class USER_CADASTRO_MODULOS
    {
        public USER_CADASTRO_MODULOS()
        {

        }

        public USER_CADASTRO_MODULOS( int _iduser, int _idmod)
        {
            id_user = _iduser;
            id_modulo = _idmod;
        }
        public int id_cadastro_modulo { get; set; }
        public int id_user { get; set; }
        public int id_modulo { get; set; }
    }
}
