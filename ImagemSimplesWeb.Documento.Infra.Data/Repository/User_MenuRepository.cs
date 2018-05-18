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
    public class User_MenuRepository : Repository<user_menu1>, IUser_MenuRepository
    {
        public User_MenuRepository(Imagem_ItapeviContext context) : base(context)
        {

        }

        public List<user_menu1> CategoriasDocumento()
        {
            var con = Db.Database.Connection;

            var sql = @"Select * from dbo.user_menu1 where existemdb like '%SIM%' ";
            var menus = con.Query<user_menu1>(sql).ToList();

            return menus;
        }
    }

}
