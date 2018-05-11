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
    public class User_PermissoesRepository : Repository<USER_PERMISSOES>, IUser_PermissoesRepository
    {
        public User_PermissoesRepository(Imagem_ItapeviContext context) : base(context)
        {

        }

        public int ExcluiAcessos(int id_user)
        {
            var con = Db.Database.Connection;

            var sql = "DELETE FROM USER_PERMISSOES WHERE id_user = @id_user";

            var rows = con.Execute(sql, new { id_user = id_user }, null, 0, null);

            return rows;
        }

        public List<DTOAcessos> RetornaAcessos(int id_user)
        {
            var con = Db.Database.Connection;

            var sql = @"SELECT  um.id_oper, um.Descricao, um.Nivel FROM USER_MENU1 um
                        INNER JOIN USER_PERMISSOES up ON up.id_oper = um.id_Oper
                        WHERE up.id_user = @id_user AND up.Acesso = 1";
            var acessos = con.Query<DTOAcessos>(sql, new { id_user = id_user }).ToList();

            return acessos;
        }

        public List<USER_MODULOS> RetornaModulos(int id_user)
        {
            var con = Db.Database.Connection;

            var sql = @"SELECT m.id_modulo 'id_modulo', m.nome_modulo 'nome_modulo'
                        FROM USER_MODULOS m INNER JOIN USER_CADASTRO_MODULOS cm ON m.id_modulo = cm.id_modulo
                        WHERE cm.id_user = @id_user";
            var modulos = con.Query<USER_MODULOS>(sql, new { id_user = id_user }).ToList();

            return modulos;
        }
    }
}
