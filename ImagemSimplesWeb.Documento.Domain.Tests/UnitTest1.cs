using System;
using ImagemSimplesWeb.Documento.Domain.Interfaces.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace ImagemSimplesWeb.Documento.Domain.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var container = new SimpleInjector.Container();
            ImagemSimplesWeb.Application.AutoMapper.AutoMapperConfig.RegisterMappings();
            ImagemSimplesWeb.Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);           
            var teste = container.GetInstance<IUser_CadastroService>();
            var teste2 = teste.BuscarTodos();            
        }
    }
}
