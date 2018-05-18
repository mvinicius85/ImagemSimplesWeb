using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.ViewModels
{
    public class User_Documentos_ImagemViewModel
    {
        public User_Documentos_ImagemViewModel()
        {
            atributos = new List<User_Documentos_AtributosViewModel>();
        }

        public User_Documentos_ImagemViewModel(int _iddoc, int _idcateg, int _idstat, string _titulo,
            string _endimg)
        {
            id_documento = _iddoc;
            id_categoria = _idcateg;
            id_status = _idstat;
            titulo = _titulo;
            endereco_imagem = _endimg;
            atributos = new List<User_Documentos_AtributosViewModel>();
        }


        public int id_documento { get; set; }
        public int id_categoria { get; set; }
        public int id_status { get; set; }
        public string titulo { get; set; }
        public string endereco_imagem { get; set; }
        public Nullable<System.DateTime> data_cadastro { get; set; }
        public string hora_cadastro { get; set; }
        public Nullable<System.DateTime> data_alteracao { get; set; }
        public string hora_alteracao { get; set; }
        public Nullable<int> id_user_alteracao { get; set; }
        public List<User_Documentos_AtributosViewModel> atributos { get; set; }
        public User_Status_DocumentoViewModel Status { get; set; }
    }
}
