using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_validacoes
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sql { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public int id_user { get; set; }
    }
}
