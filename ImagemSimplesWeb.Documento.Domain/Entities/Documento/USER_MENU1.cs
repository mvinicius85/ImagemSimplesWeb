using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_menu1
    {
        public int id_oper { get; set; }
        public Nullable<int> dependencia { get; set; }
        public string descricao { get; set; }
        public Nullable<int> codigo { get; set; }
        public Nullable<int> cod_ext { get; set; }
        public string nivel { get; set; }
        public Nullable<System.DateTime> datainclusao { get; set; }
        public Nullable<System.DateTime> dataalteracao { get; set; }
        public Nullable<int> empresa { get; set; }
        public string analitico { get; set; }
        public Nullable<int> operincluiu { get; set; }
        public Nullable<int> operalterou { get; set; }
        public string existemdb { get; set; }
        public string pathimagens { get; set; }
        public string nome { get; set; }
        public Nullable<int> id_tipo_arquivo { get; set; }
    }
}
