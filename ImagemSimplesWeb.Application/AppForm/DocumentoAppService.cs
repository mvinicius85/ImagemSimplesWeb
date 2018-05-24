using AutoMapper;
using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Application.ViewModels;
using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ImagemSimplesWeb.Application.AppForm
{
    public class DocumentoAppService : ApplicationService, IDocumentoAppService
    {
        private readonly IUser_Documento_ImagemService _documentoservice;
        public DocumentoAppService(IUser_Documento_ImagemService documentoservice,
            Documento.Infra.Data.Interfaces.IUnitOfWork uow) : base(uow)
        {
            _documentoservice = documentoservice;
        }

        public string InsereDocumento(User_Documentos_ImagemViewModel doc, string nmfile)
        {
            try
            {
                BeginDocumentoTransaction();
                var newname = Guid.NewGuid().ToString();
                var oldfile = HttpRuntime.AppDomainAppPath + "Files\\Indexar\\" + nmfile;
                doc.endereco_imagem = "Files\\Repositorio\\" + newname + ".pdf";

                var ad = _documentoservice.AdicionaDocumento(Mapper.Map<user_documentos_imagem>(doc));

                if (CommitDocumento() > 0)
                {
                    BeginDocumentoTransaction();
                    foreach (var item in doc.atributos)
                    {
                        item.id_documento = ad.id_documento;
                        _documentoservice.AdicionarAtributo(Mapper.Map<user_documentos_atributos>(item));
                    }
                    if (CommitDocumento() > 0)
                    {
                        File.Move(oldfile, HttpRuntime.AppDomainAppPath + doc.endereco_imagem);
                        return "";
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }

        }

        public DataTable RetornaDocumentos(int idoper, string query)
        {
            return _documentoservice.PesquisaDocumentos(idoper, query);
        }
    }
}
