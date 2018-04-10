using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class USER_OPERACOES
    {
        public int id { get; set; }
        public int id_Oper { get; set; }
        public string Descricao { get; set; }
        public Nullable<int> Visualizar { get; set; }
        public Nullable<int> Indexar { get; set; }
        public Nullable<int> Conferir { get; set; }
        public Nullable<int> Configurar { get; set; }
        public Nullable<int> Mover { get; set; }
        public Nullable<int> Perfil { get; set; }
        public Nullable<int> Ferramentas { get; set; }
        public Nullable<int> Relatorios { get; set; }
        public Nullable<int> livre1 { get; set; }
        public Nullable<System.DateTime> DataInclusao { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<int> OperIncluiu { get; set; }
        public Nullable<int> OperAlterou { get; set; }
        public Nullable<int> cont_docs { get; set; }
    }
}
