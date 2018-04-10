using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class USER_DOCUMENTOS
    {
        public int id { get; set; }
        public string posicao { get; set; }
        public string Atr_nome { get; set; }
        public string Atr_tipo { get; set; }
        public int Atr_tam { get; set; }
        public string DocExt { get; set; }
        public Nullable<int> validacao_id1 { get; set; }
        public Nullable<int> validacao_id2 { get; set; }
        public Nullable<int> validacao_id3 { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public int id_user { get; set; }
    }
}
