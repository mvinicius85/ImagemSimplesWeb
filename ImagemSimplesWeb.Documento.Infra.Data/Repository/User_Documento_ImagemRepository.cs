using Dapper;
using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Entities.DTO;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Infra.Data.Repository
{
    public class User_Documento_ImagemRepository : Repository<user_documentos_imagem>, IUser_Documento_ImagemRepository
    {
        public User_Documento_ImagemRepository(Imagem_ItapeviContext context) : base(context)
        {

        }

        public DataTable BuscarDocumentos(int idoper, string query)
        {
            DataTable dt = new DataTable();
            var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            var querydoc = @"Select DISTINCT udi.endereco_imagem AS imagem , udi.id_documento, udi.id_categoria, udi.titulo
                            from dbo.user_documentos_imagem udi
                            INNER JOIN dbo.user_documentos_atributos uda ON udi.id_documento = uda.id_documento
                            INNER JOIN dbo.user_cat_atributos uca ON uda.id_atributo = uca.id_cat_atrib
                            WHERE udi.id_categoria = " + idoper.ToString();
            if (!String.IsNullOrEmpty(query))
            {
                querydoc = querydoc + " and " + query;
            }
            NpgsqlCommand cmd = new NpgsqlCommand(querydoc, conn);
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

      
        }

        public List<DTODocAtributos> BuscarAtributos(int iddoc)
        {
            //DataTable dt = new DataTable();
            //var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            //var query = @"SELECT uca.nomeatributo, uca.tituloatributo, uca.ordem, uda.valor
            //                FROM dbo.user_documentos_atributos uda INNER JOIN 
            //                dbo.user_cat_atributos uca ON uda.id_atributo = uca.id_cat_atrib
            //                WHERE id_documento = " + iddoc.ToString();
            //NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            //conn.Open();
            //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            //da.Fill(dt);
            //return dt;

            var con = Db.Database.Connection;

            var sql = @"SELECT uca.nomeatributo, uca.tituloatributo, uca.ordem, uda.valor
                            FROM dbo.user_documentos_atributos uda INNER JOIN 
                            dbo.user_cat_atributos uca ON uda.id_atributo = uca.id_cat_atrib
                            WHERE id_documento = " + iddoc.ToString();
            var atribs = con.Query<DTODocAtributos>(sql, new { iddoc = iddoc }).ToList();

            return atribs.OrderBy(x => x.ordem).ToList();

        }
    }
}
