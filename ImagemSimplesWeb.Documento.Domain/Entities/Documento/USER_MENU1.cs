using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class USER_MENU1
    {
        public int id_Oper { get; set; }
        public Nullable<int> Dependencia { get; set; }
        public string Descricao { get; set; }
        public Nullable<int> Codigo { get; set; }
        public Nullable<int> Cod_Ext { get; set; }
        public string Nivel { get; set; }
        public Nullable<System.DateTime> DataInclusao { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<int> Empresa { get; set; }
        public string Analitico { get; set; }
        public Nullable<int> OperIncluiu { get; set; }
        public Nullable<int> OperAlterou { get; set; }
        public string ExisteMDB { get; set; }
        public string PATHIMAGENS { get; set; }
        public string NOME { get; set; }
    }
}
