using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.ViewModels
{
    public class User_PermissoesViewmodel
    {
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
    }
}
