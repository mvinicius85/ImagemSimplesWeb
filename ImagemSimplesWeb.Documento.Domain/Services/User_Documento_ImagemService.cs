using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Documento.Domain.Services
{
    public class User_Documento_ImagemService : IUser_Documento_ImagemService
    {
        private readonly IUser_Documento_ImagemRepository _docrepository;
        private readonly IUser_Documento_AtributosRepository _docatribrepository;
        public User_Documento_ImagemService(IUser_Documento_ImagemRepository docrepository,
            IUser_Documento_AtributosRepository docatribrepository)
        {
            _docrepository = docrepository;
            _docatribrepository = docatribrepository;
        }
        public user_documentos_imagem AdicionaDocumento(user_documentos_imagem doc)
        {
           return _docrepository.Adicionar(doc);
        }

        public void AdicionarAtributo(user_documentos_atributos user_documentos_atributos)
        {
            _docatribrepository.Adicionar(user_documentos_atributos);
        }
    }
}
