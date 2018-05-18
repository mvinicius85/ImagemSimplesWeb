using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_cat_atributos
    {
        public int id_cat_atrib { get; set; }
        public Nullable<int> id_oper { get; set; }
        public string nomeatributo { get; set; }
        public string tituloatributo { get; set; }
        public Nullable<int> ordem { get; set; }
    }
}
