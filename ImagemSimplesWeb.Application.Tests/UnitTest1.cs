using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using ImagemSimplesWeb.Application.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImagemSimplesWeb.Application.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestApplication1()
        {
            ImagemSimplesWeb.Application.AutoMapper.AutoMapperConfig.RegisterMappings();
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            var teste = container.GetInstance<ICadastroAppService>();
            var teste2 = teste.ListaCadastro();

        }

        [TestMethod]
        public void AbrirArquivo()
        {
            string path = @"C:\Camara Municipal de Itapevi\Documentos 1995\Secretaria Executiva\Processo Legislativo\PROCESSO LEGISLATIVO.MDB";
            string pathfile = @"C:\Camara Municipal de Itapevi\Documentos 1995\Secretaria Executiva\Processo Legislativo\";
            string connectionName = "Provider=Microsoft.Jet.OLEDB.4.0;"
              + "Data Source= " + path + " ;";

            ImagemSimplesWeb.Application.AutoMapper.AutoMapperConfig.RegisterMappings();
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            var teste = container.GetInstance<IArquivoAppService>();
            var teste2 = teste.AbreArquivo(connectionName, "");

            Process.Start(pathfile + teste2.Rows[4].ItemArray[4].ToString());

        }
        [TestMethod]
        public void ValidarLogin()
        {
            ImagemSimplesWeb.Application.AutoMapper.AutoMapperConfig.RegisterMappings();
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            var teste = container.GetInstance<ICadastroAppService>();
            var teste2 = teste.ValidaLogin("WALTER", "123");
        }

        [TestMethod]
        public void RetornaMenu()
        {
            ImagemSimplesWeb.Application.AutoMapper.AutoMapperConfig.RegisterMappings();
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            var teste = container.GetInstance<ICadastroAppService>();
            var teste2 = teste.BuscaMenu();
            teste2 = teste2.OrderByDescending(x => x.id_Oper).ToList();
            foreach (var item in teste2)
            {
                if (item.Dependencia > 0)
                {
                    teste2.Where(y => y.id_Oper == item.Dependencia).FirstOrDefault().submenu.Add(item);
                }
            }
            var final = teste2.Where(x => x.Dependencia == 0).OrderBy(y => y.id_Oper).ToList();
        }
    }
}
