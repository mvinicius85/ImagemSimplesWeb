using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.ViewModels
{
    public class User_CadastroViewModel
    {
        public User_CadastroViewModel()
        {

        }
        public User_CadastroViewModel(int _id, string _senha, string _cod, string _nome, string _depto, string _data,
            string _dtini, string _tel1, string _tel2, string _tel3, string _email, bool _ativo)
        {
            id_user = _id;
            Senha = _senha;
            codigo = _cod;
            Nome = _nome;
            Depto = _depto;
            Data = _data;
            DataInicio = _dtini;
            Tel1 = _tel1;
            Tel2 = _tel2;
            Tel3 = _tel3;
            Email = _email;
            ativo = _ativo;
        }
        public int id_user { get; set; }
        public string codigo { get; set; }
        public string Nome { get; set; }
        public string Depto { get; set; }
        public string Data { get; set; }
        public string DataInicio { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Tel3 { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string LiberaRequisicao { get; set; }
        public string Assinatura { get; set; }
        public string nomepc { get; set; }
        public string secao { get; set; }
        public Nullable<bool> ativo { get; set; }
    }
}
