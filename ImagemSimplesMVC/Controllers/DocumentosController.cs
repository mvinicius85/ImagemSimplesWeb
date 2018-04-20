using ImagemSimplesWeb.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImagemSimplesMVC.Controllers
{
    public class DocumentosController : Controller
    {
        // GET: Documentos
        public ActionResult Documento()
        {
            {
                string path = @"C:\Camara Municipal de Itapevi\Documentos 1995\Secretaria Executiva\Processo Legislativo\PROCESSO LEGISLATIVO.MDB";

                ImagemSimplesWeb.Application.AutoMapper.AutoMapperConfig.RegisterMappings();
                var container = new SimpleInjector.Container();
                ImagemSimplesWeb.Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
                var teste = container.GetInstance<IArquivoAppService>();
                var teste2 = teste.AbreArquivo(path, "");

                return View(teste2);

                
            }
        }
    }
}