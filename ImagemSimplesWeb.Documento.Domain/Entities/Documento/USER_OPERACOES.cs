using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_operacoes
    {
        public int id { get; set; }
        public int id_oper { get; set; }
        public string descricao { get; set; }
        public Nullable<int> visualizar { get; set; }
        public Nullable<int> indexar { get; set; }
        public Nullable<int> conferir { get; set; }
        public Nullable<int> configurar { get; set; }
        public Nullable<int> mover { get; set; }
        public Nullable<int> perfil { get; set; }
        public Nullable<int> ferramentas { get; set; }
        public Nullable<int> relatorios { get; set; }
        public Nullable<int> livre1 { get; set; }
        public Nullable<System.DateTime> datainclusao { get; set; }
        public Nullable<System.DateTime> dataalteracao { get; set; }
        public Nullable<int> operincluiu { get; set; }
        public Nullable<int> operalterou { get; set; }
        public Nullable<int> cont_docs { get; set; }
    }
}
