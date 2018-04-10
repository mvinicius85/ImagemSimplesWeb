using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class USER_VINCULOS_ATRI
    {
        public int id_ass { get; set; }
        public string Atr_Trabalho { get; set; }
        public string Atr_Base { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public int id_user { get; set; }
    }
}
