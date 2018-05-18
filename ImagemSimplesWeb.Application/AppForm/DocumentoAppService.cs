using AutoMapper;
using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Application.ViewModels;
using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string InsereDocumento(User_Documentos_ImagemViewModel doc)
        {
            try
            {
                BeginDocumentoTransaction();
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
    }
}
