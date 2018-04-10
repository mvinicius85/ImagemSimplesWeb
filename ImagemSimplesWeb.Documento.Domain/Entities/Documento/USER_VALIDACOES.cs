using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class USER_VALIDACOES
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string SQL { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public int id_user { get; set; }
    }
}
