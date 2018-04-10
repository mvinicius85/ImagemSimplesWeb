using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class USER_DOC_ATRIBUTOS
    {
        public int id { get; set; }
        public int id_doc { get; set; }
        public int id_atr { get; set; }
        public string Validar { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public int id_user { get; set; }
    }
}
