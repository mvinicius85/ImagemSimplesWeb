using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_documentos_atributos
    {
        public int id_doc_atrib { get; set; }
        public int id_documento { get; set; }
        public int id_atributo { get; set; }
        public string valor { get; set; }
    }
}
