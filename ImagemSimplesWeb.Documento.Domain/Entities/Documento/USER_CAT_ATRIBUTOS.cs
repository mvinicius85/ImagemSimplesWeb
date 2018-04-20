using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class USER_CAT_ATRIBUTOS
    {
        public int id_cat_atrib { get; set; }
        public Nullable<int> id_Oper { get; set; }
        public string NomeAtributo { get; set; }
        public string TituloAtributo { get; set; }
        public Nullable<int> Ordem { get; set; }
    }
}
