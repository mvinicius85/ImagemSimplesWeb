using AutoMapper;
using ImagemSimplesWeb.Application.AppForm;
using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Core.Domain.Interfaces.Services;
using ImagemSimplesWeb.Core.Domain.Services;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Repository;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Services;
using ImagemSimplesWeb.Documento.Domain.Services;
using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using ImagemSimplesWeb.Documento.Infra.Data.Repository;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Lifestyles;

namespace ImagemSimplesWeb.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            AsyncScopedLifestyle.BeginScope(container);

            // App 
            #region Apps
            container.Register<ICadastroAppService, CadastroAppService>(Lifestyle.Scoped);
            container.Register<IArquivoAppService, ArquivoAppService>(Lifestyle.Scoped);
            #endregion


            #region Services
            container.Register<IUser_CadastroService, User_CadastroService>(Lifestyle.Scoped);
            container.Register<IMdbFileService, MdbFileService>(Lifestyle.Scoped);
            container.Register<IUser_MenuService, User_MenuService>(Lifestyle.Scoped);
            container.Register<IUser_PermissoesService, User_PermissoesService>(Lifestyle.Scoped);
            #endregion

            #region Repository
            container.Register<IUser_CadastroRepository, User_CadastroRepository>(Lifestyle.Scoped);
            container.Register<IUser_MenuRepository, User_MenuRepository>(Lifestyle.Scoped);
            container.Register<IUser_Cat_AtributoRepository, User_Cat_AtributoRepository>(Lifestyle.Scoped);
            container.Register<IUser_PermissoesRepository, User_PermissoesRepository>(Lifestyle.Scoped);
            container.Register<IUser_Cadastro_ModulosRepository, User_Cadastro_ModulosRepository>(Lifestyle.Scoped);
            #endregion


            container.RegisterSingleton(Mapper.Configuration);
            container.Register<IMapper>(() => Mapper.Configuration.CreateMapper(container.GetInstance));

            container.Register<ImagemSimplesWeb.Documento.Infra.Data.Interfaces.IUnitOfWork, ImagemSimplesWeb.Documento.Infra.Data.UoW.UnitOfWork>(Lifestyle.Scoped);
            container.Register<Imagem_ItapeviContext>(Lifestyle.Singleton);
        }
    }
}
