using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_documentos_imagem
    {
        public int id_documento { get; set; }
        public int id_categoria { get; set; }
        public int id_status { get; set; }
        public string titulo { get; set; }
        public string endereco_imagem { get; set; }
        public Nullable<System.DateTime> data_cadastro { get; set; }
        public string hora_cadastro { get; set; }
        public Nullable<System.DateTime> data_alteracao { get; set; }
        public string hora_alteracao { get; set; }
        public Nullable<int> id_user_alteracao { get; set; }
    }
}
