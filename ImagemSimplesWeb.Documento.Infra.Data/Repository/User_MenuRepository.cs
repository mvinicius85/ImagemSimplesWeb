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
    public class User_MenuRepository : Repository<user_menu1>, IUser_MenuRepository
    {
        public User_MenuRepository(Imagem_ItapeviContext context) : base(context)
        {

        }

        public int AddDapper(user_menu1 cat)
        {
            var con = Db.Database.Connection;

            var sql = @"INSERT INTO dbo.user_menu1 (id_oper, dependencia, descricao, nivel, 
                            datainclusao,  operincluiu, operalterou, existemdb, pathimagens, nome, id_tipo_arquivo, ind_ativo)
                    VALUES (@id_oper, @dependencia, @descricao, @nivel, @datainclusao, @operincluiu, @operalterou,
                        @existemdb, @pathimagens, @nome, @id_tipo_arquivo, @ind_ativo)";



            var menus = con.Execute(sql, cat);

            return menus;
        }

        public List<user_menu1> CategoriasDocumento()
        {
            var con = Db.Database.Connection;

            var sql = @"Select * from dbo.user_menu1 where existemdb like '%SIM%' ";
            var menus = con.Query<user_menu1>(sql).ToList();

            return menus;
        }

        public List<user_menu1> RetornaCategorias(DTOCategorias filtro)
        {
            var con = Db.Database.Connection;

            var sql = @"Select * from dbo.user_menu1 " + filtro.SWhere();
            var menus = con.Query<user_menu1>(sql, filtro).ToList();

            return menus;
        }

        public int UltimoId()
        {
            var con = Db.Database.Connection;

            var sql = @"Select COALESCE(max(id_oper),0) + 1 from dbo.user_menu1";
            var id = con.Query<int>(sql).FirstOrDefault();
            return id;
        }
    }

}
