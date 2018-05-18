using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_liberareq
    {
        public int id_user { get; set; }
        public string codigo { get; set; }
        public string nome { get; set; }
        public string depto { get; set; }
        public string data { get; set; }
        public Nullable<bool> libera { get; set; }
    }
}
