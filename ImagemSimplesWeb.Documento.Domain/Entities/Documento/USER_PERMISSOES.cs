using System;
using System.Collections.Generic;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_permissoes
    {
        public user_permissoes()
        {

        }
        public user_permissoes(string _iduser, int _idoper, string _nivel, bool _acesso)
        {
            id_user = _iduser;
            id_oper = _idoper;
            nivel = _nivel;
            acesso = _acesso;
        }
        public string id_user { get; set; }
        public int id_oper { get; set; }
        public string sub_oper { get; set; }
        public string nivel { get; set; }
        public Nullable<bool> acesso { get; set; }
        public Nullable<bool> incluir { get; set; }
        public Nullable<bool> alterar { get; set; }
        public Nullable<bool> excluir { get; set; }
        public Nullable<bool> inativar { get; set; }
        public string observacao { get; set; }
        public virtual user_menu1 USER_MENU1 { get; set; }
    }
}
