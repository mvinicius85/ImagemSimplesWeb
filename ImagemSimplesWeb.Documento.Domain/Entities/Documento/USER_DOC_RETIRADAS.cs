using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class USER_DOC_RETIRADAS
    {
        public int id { get; set; }
        public string documento { get; set; }
        public string Solicitante { get; set; }
        public string cpf_rg { get; set; }
        public System.DateTime Dataretirada { get; set; }
        public System.DateTime Datadevolucao { get; set; }
        public Nullable<int> id_entregador { get; set; }
        public Nullable<int> id_recebedor { get; set; }
        public int status { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public int id_user { get; set; }
    }
}
