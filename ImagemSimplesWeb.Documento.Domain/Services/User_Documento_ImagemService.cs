using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Services
{
    public class User_Documento_ImagemService : IUser_Documento_ImagemService
    {
        private readonly IUser_Documento_ImagemRepository _docrepository;
        private readonly IUser_Documento_AtributosRepository _docatribrepository;
        private readonly IUser_Cat_AtributoRepository _catatributos;
        public User_Documento_ImagemService(IUser_Documento_ImagemRepository docrepository,
            IUser_Documento_AtributosRepository docatribrepository,
            IUser_Cat_AtributoRepository catatributos)
        {
            _docrepository = docrepository;
            _docatribrepository = docatribrepository;
            _catatributos = catatributos;
        }
        public user_documentos_imagem AdicionaDocumento(user_documentos_imagem doc)
        {
            doc.data_cadastro = DateTime.Now;
            doc.hora_cadastro = DateTime.Now.ToString("h:mm:ss tt");
           return _docrepository.Adicionar(doc);
        }

        public void AdicionarAtributo(user_documentos_atributos user_documentos_atributos)
        {
            _docatribrepository.Adicionar(user_documentos_atributos);
        }

        public DataTable PesquisaDocumentos(int idoper, string query)
        {
            DataTable dt = new DataTable();
            var ret = _docrepository.BuscarDocumentos(idoper, query);
            var atribs = _catatributos.Buscar(x => x.id_oper == idoper).ToList();
            dt.Columns.Add(new DataColumn("imagem"));
            dt.Columns.Add(new DataColumn("id_documento"));
            foreach (var atrib in atribs)
            {
                dt.Columns.Add(atrib.nomeatributo);
            }
            
            foreach (DataRow item in ret.Rows)
            {
                var docatribs = _docrepository.BuscarAtributos(Convert.ToInt32(item["id_documento"]));
                var r = dt.NewRow();
                r["imagem"] = item["imagem"];
                r["id_documento"] = item["id_documento"];
                foreach (var at in atribs)
                {
                    r[at.nomeatributo] = docatribs.Where(x => x.nomeatributo == at.nomeatributo).FirstOrDefault().valor;
                }
                dt.Rows.Add(r);
            }
            return dt;
        }
    }
}
