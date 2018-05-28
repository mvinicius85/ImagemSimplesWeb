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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<User_CadastroViewModel, user_cadastro>();
            CreateMap<User_MenuViewModel, user_menu1>();
            CreateMap<AcessosViewModel, DTOAcessos>();
            CreateMap<User_Documentos_ImagemViewModel, user_documentos_imagem>();
            CreateMap<User_Documentos_AtributosViewModel, user_documentos_atributos>();
            CreateMap<User_Status_DocumentoViewModel, user_status_documento>();
            CreateMap<frmCategoriasViewModel, DTOCategorias>();
        }
    }


}
