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
        }
        public List<User_MenuViewModel> Menus { get; set; }
    }


}
