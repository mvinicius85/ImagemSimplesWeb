using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.ViewModels
{
    public class frmCadCategoriaViewModel
    {
        public frmCadCategoriaViewModel()
        {
            Menus = new List<User_MenuViewModel>();
            TiposArquivo = new List<User_Tipo_ArquivoViewModel>();
        }
        public List<User_MenuViewModel> Menus { get; set; }
        public List<User_Tipo_ArquivoViewModel> TiposArquivo { get; set; }
    }


}
