using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class USER_LIBERAREQ
    {
        public int id_user { get; set; }
        public string codigo { get; set; }
        public string Nome { get; set; }
        public string Depto { get; set; }
        public string Data { get; set; }
        public Nullable<bool> Libera { get; set; }
    }
}
