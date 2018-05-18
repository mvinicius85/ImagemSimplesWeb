using Dapper;
using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Infra.Data.Repository
{
    public class User_Cat_AtributoRepository : Repository<user_cat_atributos>, IUser_Cat_AtributoRepository
    {
        public User_Cat_AtributoRepository(Imagem_ItapeviContext context) : base(context)
        {

        }

        public int ExcluirAtributos(int id_oper)
        {
            var con = Db.Database.Connection;

            var sql = "DELETE FROM dbo.user_cat_atributos WHERE id_oper = @id_oper";

            var rows = con.Execute(sql, new { id_oper = id_oper }, null, 0, null);

            return rows;
        }
    }
}
