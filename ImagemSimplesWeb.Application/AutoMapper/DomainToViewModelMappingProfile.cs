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
            CreateMap<USER_CADASTRO, User_CadastroViewModel>();
            CreateMap<USER_MENU1, User_MenuViewModel>();
            CreateMap<DTOAcessos, AcessosViewModel>();
        }
    }
}
