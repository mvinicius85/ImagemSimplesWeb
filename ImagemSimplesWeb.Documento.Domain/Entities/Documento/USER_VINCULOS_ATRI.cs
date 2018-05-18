using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_vinculos_atri
    {
        public int id_ass { get; set; }
        public string atr_trabalho { get; set; }
        public string atr_base { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public int id_user { get; set; }
    }
}
