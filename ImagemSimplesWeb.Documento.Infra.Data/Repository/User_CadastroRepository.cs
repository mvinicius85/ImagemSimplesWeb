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
    public class User_CadastroRepository : Repository<user_cadastro>, IUser_CadastroRepository
    {
        public User_CadastroRepository(Imagem_ItapeviContext context) : base(context)
        {

        }

        public List<user_cadastro> FiltrarUsuarios(user_cadastro filtro)
        {
            var con = Db.Database.Connection;

            var sql = @"Select * from dbo.USER_CADASTRO " + filtro.MontaSwhere();
            var nfes = con.Query<user_cadastro>(sql, filtro).ToList();

            return nfes.OrderBy(x => x.id_user).ToList();
        }
    }
}
