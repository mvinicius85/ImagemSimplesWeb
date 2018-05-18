using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_vinculos
    {
        public int id { get; set; }
        public string nome_doc { get; set; }
        public string nome_ass { get; set; }
        public string arquivo_trabalho { get; set; }
        public string arquivo_base { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public int id_user { get; set; }
    }
}
