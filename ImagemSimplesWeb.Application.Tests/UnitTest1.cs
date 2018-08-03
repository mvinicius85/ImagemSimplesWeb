using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Application.Model;
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

        [TestMethod]
        public async void TestApi()
        {
            string param1 = "user";
            string param2 = "senha";
            var endpoint = $"http://192.168.1.32/Decrypt/api/Encrypt/{param1},{param2}";
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    
                }
                else
                {
                    //await context.PostAsync("Aguarde um momento por favor.");
                    var json = await response.Content.ReadAsStringAsync();
                    var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json);
                    //await context.PostAsync("Encontrei os seguintes itens para voce:");

                    //var cotacoes = resultado.Cotacoes?.Select(c => $"{c.Nome" : {c.Valor}");
                    //await context.PostAsync($"{string.Join(", ",cotacores.toArray())});
                    //await context.PostAsync("Seguem os dados do produto solicitado: Nome" + resultado.Nome + ", Valor: " + resultado.Preco);
                }


            }
        }
    }
}