using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_doc_retiradas
    {
        public int id { get; set; }
        public string documento { get; set; }
        public string solicitante { get; set; }
        public string cpf_rg { get; set; }
        public System.DateTime dataretirada { get; set; }
        public System.DateTime datadevolucao { get; set; }
        public Nullable<int> id_entregador { get; set; }
        public Nullable<int> id_recebedor { get; set; }
        public int status { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public int id_user { get; set; }
    }
}
