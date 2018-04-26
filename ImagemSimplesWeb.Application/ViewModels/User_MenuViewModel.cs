using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.ViewModels
{
    public class User_MenuViewModel
    {
        public User_MenuViewModel(int _idop, int _iddep, string _desc, string _nivel, string _mdb, string _path)
        {
            id_Oper = _idop;
            Dependencia = _iddep;
            Descricao = _desc;
            Nivel = _nivel;
            ExisteMDB = _mdb;
            PATHIMAGENS = _path;
        }
        public User_MenuViewModel()
        {
            submenu = new List<User_MenuViewModel>();
        }

        public User_MenuViewModel(int _idop, string _desc)
        {
            id_Oper = _idop;
            Descricao = _desc;
        }
        public int id_Oper { get; set; }
        public Nullable<int> Dependencia { get; set; }
        public string Descricao { get; set; }
        public Nullable<int> Codigo { get; set; }
        public Nullable<int> Cod_Ext { get; set; }
        public string Nivel { get; set; }
        public Nullable<System.DateTime> DataInclusao { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<int> Empresa { get; set; }
        public string Analitico { get; set; }
        public Nullable<int> OperIncluiu { get; set; }
        public Nullable<int> OperAlterou { get; set; }
        public string ExisteMDB { get; set; }
        public string PATHIMAGENS { get; set; }
        public List<User_MenuViewModel> submenu { get; set; }
        public List<USER_CAT_ATRIBUTOSViewModel> Atributos { get; set; }
        public string link { get { return "Documento.aspx?idoper=" + this.id_Oper.ToString();  }}
        public string DescNivel { get { return Nivel + " - " +  Descricao.TrimEnd(); } }
    }
}
