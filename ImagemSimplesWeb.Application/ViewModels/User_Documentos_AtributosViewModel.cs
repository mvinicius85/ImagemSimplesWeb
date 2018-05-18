using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.ViewModels
{
    public class User_Documentos_AtributosViewModel
    {
        public User_Documentos_AtributosViewModel()
        {

        }

        public User_Documentos_AtributosViewModel(int _iddocatrib, int _iddoc, int _idatrib,
            string _valor)
        {
            id_doc_atrib = _iddocatrib;
            id_documento = _iddoc;
            id_atributo = _idatrib;
            valor = _valor;

        }
        public int id_doc_atrib { get; set; }
        public int id_documento { get; set; }
        public int id_atributo { get; set; }
        public string valor { get; set; }
    }
}
