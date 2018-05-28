using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.ViewModels
{
    public class frmCategoriasViewModel
    {
        public frmCategoriasViewModel()
        {

        }
        public frmCategoriasViewModel(string _desc, string _nome, string _tparmaz)
        {
            descricao = _desc;
            nome = _nome;
            tipoarmazenamento = _tparmaz;
        }

        public string nome { get; set; }
        public string descricao { get; set; }
        public string tipoarmazenamento { get; set; }
    }
}
