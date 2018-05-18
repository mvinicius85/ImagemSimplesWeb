using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_doc_atributos
    {
        public int id { get; set; }
        public int id_doc { get; set; }
        public int id_atr { get; set; }
        public string validar { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public int id_user { get; set; }
    }
}
