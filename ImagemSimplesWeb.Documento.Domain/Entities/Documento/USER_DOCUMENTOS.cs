using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_documentos
    {
        public int id { get; set; }
        public string posicao { get; set; }
        public string atr_nome { get; set; }
        public string atr_tipo { get; set; }
        public int atr_tam { get; set; }
        public string docext { get; set; }
        public Nullable<int> validacao_id1 { get; set; }
        public Nullable<int> validacao_id2 { get; set; }
        public Nullable<int> validacao_id3 { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public int id_user { get; set; }
    }
}
