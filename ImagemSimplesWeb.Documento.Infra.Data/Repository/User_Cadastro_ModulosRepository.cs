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
    public class User_Cadastro_ModulosRepository : Repository<USER_CADASTRO_MODULOS>, IUser_Cadastro_ModulosRepository
    {
        public User_Cadastro_ModulosRepository(Imagem_ItapeviContext context) : base(context)
        {

        }

        public int ExcluirModulos(int id_user)
        {
            var con = Db.Database.Connection;

            var sql = "DELETE FROM USER_CADASTRO_MODULOS WHERE id_user = @id_user";

            var rows = con.Execute(sql, new { id_user = id_user }, null, 0, null);

            return rows;
        }
    }
}
