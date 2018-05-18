using Dapper;
using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Entities.DTO;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Infra.Data.Repository
{
    public class User_PermissoesRepository : Repository<user_permissoes>, IUser_PermissoesRepository
    {
        public User_PermissoesRepository(Imagem_ItapeviContext context) : base(context)
        {

        }

        public int ExcluiAcessos(int id_user)
        {

            string iduser = id_user.ToString();

            var con = Db.Database.Connection;

            var sql = "DELETE FROM dbo.user_permissoes WHERE id_user = @iduser";

            var rows = con.Execute(sql, new { iduser = iduser }, null, 0, null);

            return rows;
        }

        public List<DTOAcessos> RetornaAcessos(int id_user)
        {
            string iduser = id_user.ToString();
            var con = Db.Database.Connection;

            var sql = @"SELECT  um.id_oper AS id_oper, um.descricao AS descricao, um.nivel AS nivel 
                        FROM dbo.user_menu1 um
                        INNER JOIN dbo.user_permissoes up ON up.id_oper = um.id_oper
                        WHERE up.id_user = @iduser AND up.acesso = true";
            var acessos = con.Query<DTOAcessos>(sql, new { iduser = iduser }).ToList();

            return acessos;
        }

        public List<user_modulos> RetornaModulos(int id_user)
        {
            var con = Db.Database.Connection;

            var sql = @"SELECT m.id_modulo as id_modulo, m.nome_modulo as nome_modulo
                        FROM dbo.user_modulos m INNER JOIN dbo.user_cadastro_modulos cm ON m.id_modulo = cm.id_modulo
                        WHERE cm.id_user = @id_user";
            var modulos = con.Query<user_modulos>(sql, new { id_user = id_user }).ToList();

            return modulos;
        }
    }
}
