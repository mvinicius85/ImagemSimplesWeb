using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.ViewModels
{
    public class User_ModulosViewModel
    {
        public User_ModulosViewModel()
        {
            
        }

        public User_ModulosViewModel(int _id, string _mod)
        {
            id_modulo = _id;
            nome_modulo = _mod;
        }
        public int id_modulo { get; set; }
        public string nome_modulo { get; set; }
    }
}
