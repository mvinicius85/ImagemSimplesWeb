using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class USER_PERMISSOES
    {
        public USER_PERMISSOES()
        {

        }
        public USER_PERMISSOES(string _iduser, int _idoper, string _nivel, bool _acesso)
        {
            id_user = _iduser;
            id_oper = _idoper;
            Nivel = _nivel;
            Acesso = _acesso;
        }
        public string id_user { get; set; }
        public int id_oper { get; set; }
        public string sub_oper { get; set; }
        public string Nivel { get; set; }
        public Nullable<bool> Acesso { get; set; }
        public Nullable<bool> Incluir { get; set; }
        public Nullable<bool> Alterar { get; set; }
        public Nullable<bool> Excluir { get; set; }
        public Nullable<bool> Inativar { get; set; }
        public string Observacao { get; set; }
        public virtual USER_MENU1 USER_MENU1 { get; set; }
    }
}
