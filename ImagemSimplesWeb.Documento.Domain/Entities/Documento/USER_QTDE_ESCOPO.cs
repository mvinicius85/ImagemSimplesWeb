using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_qtde_escopo
    {
        public int id { get; set; }
        public string documentos { get; set; }
        public string imagens { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public int id_user { get; set; }
    }
}
