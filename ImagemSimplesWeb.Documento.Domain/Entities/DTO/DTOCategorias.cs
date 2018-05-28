using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Entities.DTO
{
    public class DTOCategorias
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        public string tipoarmazenamento  { get; set; }

        public string SWhere()
        {
            StringBuilder swhere = new StringBuilder();
            if (!String.IsNullOrEmpty(nome))
            {
                swhere.Append(" UPPER(nome) LIKE '%" + nome.ToUpper() + "%'");
            }
            if (!String.IsNullOrEmpty(descricao))
            {
                if (swhere.Length > 0)
                {
                    swhere.Append(" and ");
                }
                swhere.Append(" UPPER(descricao) like '%" + descricao.ToUpper() + "%'");
            }

            switch (tipoarmazenamento)
            {
                case "1":
                    if (swhere.Length > 0)
                    {
                        swhere.Append(" and ");
                    }
                    swhere.Append("existemdb = 'SIM' ");
                    break;
                case "2":
                    if (swhere.Length > 0)
                    {
                        swhere.Append(" and ");
                    }
                    swhere.Append("existemdb = 'NÃO' ");
                    break;
            }
            if (swhere.Length > 0)
            {
                return " where " + swhere.ToString();
            }
            return swhere.ToString();
        }
    }
}
