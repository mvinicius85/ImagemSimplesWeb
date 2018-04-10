using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class USER_DOC_VINCULO
    {

        public int id { get; set; }
        public int id_doc { get; set; }
        public string Nome_doc { get; set; }
        public string Arquivo_Trabalho { get; set; }
        public string Arquivo_Base { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public int id_user { get; set; }
    }
}
