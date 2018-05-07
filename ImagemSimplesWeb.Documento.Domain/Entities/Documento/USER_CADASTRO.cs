using System;
using System.Collections.Generic;
using System.Text;

namespace ImagemSimplesWeb.Documento.Domain.Entities.Documento
{
    public partial class USER_CADASTRO
    {
        public USER_CADASTRO()
        {

        }
        public USER_CADASTRO(string user, string senha)
        {
            this.Nome = user;
            this.Senha = senha;
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

        public string MontaSwhere()
        {
            StringBuilder swhere = new StringBuilder();
            if (!String.IsNullOrEmpty(this.Nome))
            {
                swhere.Append(" Nome like '%" + this.Nome + "%'");
            }
            if (!String.IsNullOrEmpty(this.Depto))
            {
                if (swhere.Length > 1)
                {
                    swhere.Append(" and ");
                }
                swhere.Append(" Depto like '" + this.Depto + "'");
            }
            if (swhere.Length > 0)
            {
                return " where " + swhere.ToString();
            }
            return "";
        }
    }
}
