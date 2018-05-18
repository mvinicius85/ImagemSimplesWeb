using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_menuimagem
    {
        public int id { get; set; }
        public int id_doc { get; set; }
        public Nullable<System.DateTime> data { get; set; }
        public string documento { get; set; }
        public string pasta { get; set; }
        public string imagem { get; set; }
        public Nullable<System.DateTime> datainclusao { get; set; }
        public Nullable<System.DateTime> dataalteracao { get; set; }
        public Nullable<int> operincluiu { get; set; }
        public Nullable<int> operalterou { get; set; }
    }
}
