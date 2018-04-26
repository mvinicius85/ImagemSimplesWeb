using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Entities.DTO
{
    public class DTOAcessoPermissoes
    {
        public int Id_Oper { get; set; }
        public string Descricao { get; set; }
        public string Nivel { get; set; }
        public bool Acesso { get; set; }
    }
}
