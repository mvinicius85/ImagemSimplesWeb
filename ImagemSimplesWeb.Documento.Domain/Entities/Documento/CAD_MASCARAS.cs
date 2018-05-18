using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class cad_mascaras
    {
        public int id_oper { get; set; }
        public Nullable<int> dependencia { get; set; }
        public string descricao { get; set; }
        public string tabela { get; set; }
        public string nivel { get; set; }
        public Nullable<int> subniveis { get; set; }
        public string mascara { get; set; }
        public Nullable<int> codigo { get; set; }
        public Nullable<System.DateTime> datainclusao { get; set; }
        public Nullable<System.DateTime> dataalteracao { get; set; }
        public Nullable<int> empresa { get; set; }
        public string analitico { get; set; }
        public Nullable<int> operincluiu { get; set; }
        public Nullable<int> operalterou { get; set; }
        public string utilizada { get; set; }
    }
}
