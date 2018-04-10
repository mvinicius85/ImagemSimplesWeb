using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class USER_MENUIMAGEM
    {
        public int id { get; set; }
        public int id_doc { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public string Documento { get; set; }
        public string Pasta { get; set; }
        public string imagem { get; set; }
        public Nullable<System.DateTime> DataInclusao { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<int> OperIncluiu { get; set; }
        public Nullable<int> OperAlterou { get; set; }
    }
}
