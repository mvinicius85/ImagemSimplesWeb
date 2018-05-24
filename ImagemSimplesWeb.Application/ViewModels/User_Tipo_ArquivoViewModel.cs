using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.ViewModels
{
    public class User_Tipo_ArquivoViewModel
    {
        public User_Tipo_ArquivoViewModel()
        {

        }

        public User_Tipo_ArquivoViewModel(int _id, string _desc)
        {
            id_tipo_arquivo = _id;
            descricao = _desc;
        }

        public int id_tipo_arquivo { get; set; }
        public string descricao { get; set; }
    }
}
