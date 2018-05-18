using System;
using System.Collections.Generic;
using System.Text;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class user_cadastro
    {
        public user_cadastro()
        {

        }
        public user_cadastro(string user, string senha)
        {
            this.nome = user;
            this.senha = senha;
        }
        public int id_user { get; set; }
        public string codigo { get; set; }
        public string nome { get; set; }
        public string depto { get; set; }
        public string data { get; set; }
        public string datainicio { get; set; }
        public string tel1 { get; set; }
        public string tel2 { get; set; }
        public string tel3 { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string liberarequisicao { get; set; }
        public string assinatura { get; set; }
        public string nomepc { get; set; }
        public string secao { get; set; }
        public bool ativo { get; set; }

        public string MontaSwhere()
        {
            StringBuilder swhere = new StringBuilder();
            if (!String.IsNullOrEmpty(this.nome))
            {
                swhere.Append(" Nome like '%" + this.nome + "%'");
            }
            if (!String.IsNullOrEmpty(this.depto))
            {
                if (swhere.Length > 1)
                {
                    swhere.Append(" and ");
                }
                swhere.Append(" Depto like '" + this.depto + "'");
            }
            if (swhere.Length > 0)
            {
                return " where " + swhere.ToString();
            }
            return "";
        }
    }
}
