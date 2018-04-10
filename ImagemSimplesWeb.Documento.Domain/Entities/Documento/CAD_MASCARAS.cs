using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class CAD_MASCARAS
    {
        public int id_Oper { get; set; }
        public Nullable<int> Dependencia { get; set; }
        public string Descricao { get; set; }
        public string Tabela { get; set; }
        public string Nivel { get; set; }
        public Nullable<int> SubNiveis { get; set; }
        public string Mascara { get; set; }
        public Nullable<int> Codigo { get; set; }
        public Nullable<System.DateTime> DataInclusao { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<int> Empresa { get; set; }
        public string Analitico { get; set; }
        public Nullable<int> OperIncluiu { get; set; }
        public Nullable<int> OperAlterou { get; set; }
        public string Utilizada { get; set; }
    }
}
