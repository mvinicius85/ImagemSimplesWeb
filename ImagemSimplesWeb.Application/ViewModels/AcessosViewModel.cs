using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.ViewModels
{
    public class AcessosViewModel
    {
        public AcessosViewModel()
        {

        }
        public AcessosViewModel(int _id, string _desc, string _nivel)
        {
            id_oper = _id;
            Descricao = _desc;
            Nivel = _nivel;
        }
        public int id_oper { get; set; }
        public string Descricao { get; set; }
        public string Nivel { get; set; }
        public bool Acesso { get; set; }
    }
}
