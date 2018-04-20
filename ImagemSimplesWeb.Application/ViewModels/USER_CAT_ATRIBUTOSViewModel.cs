using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.ViewModels
{
    public class USER_CAT_ATRIBUTOSViewModel
    {
        public USER_CAT_ATRIBUTOSViewModel()
        {

        }
        public USER_CAT_ATRIBUTOSViewModel(int _idoper, string _nome, string _titulo)
        {
            id_Oper = _idoper;
            NomeAtributo = _nome;
            TituloAtributo = _titulo;
        }
        public int id_cat_atrib { get; set; }
        public Nullable<int> id_Oper { get; set; }
        public string NomeAtributo { get; set; }
        public string TituloAtributo { get; set; }
        public Nullable<int> Ordem { get; set; }
    }
}
