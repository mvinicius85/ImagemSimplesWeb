using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Entities.DTO
{
    public class DTOAcessos
    {
        public int id_oper { get; set; }
        public string Descricao { get; set; }
        public string  Nivel { get; set; }
        public bool Acesso { get; set; }
    }
}
