using AutoMapper;
using ImagemSimplesWeb.Application.ViewModels;
using ImagemSimplesWeb.Documento.Domain.Entities.Documento;
using ImagemSimplesWeb.Documento.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagemSimplesWeb.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<user_cadastro, User_CadastroViewModel>();
            CreateMap<user_menu1, User_MenuViewModel>();
            CreateMap<DTOAcessos, AcessosViewModel>();
            CreateMap<user_documentos_imagem, User_Documentos_ImagemViewModel>();
            CreateMap<user_documentos_atributos, User_Documentos_AtributosViewModel>();
            CreateMap<user_status_documento, User_Status_DocumentoViewModel>();
        }
    }
}
