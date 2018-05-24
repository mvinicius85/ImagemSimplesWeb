using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImagemSimplesWeb.Documentos
{
    public partial class ListaIndexar : System.Web.UI.Page
    {
        private readonly ICadastroAppService service;
        int id;
        public ListaIndexar()
        {
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            service = container.GetInstance<ICadastroAppService>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            var login = Session["Login"];
            if (login == null)
            {
                Response.Redirect("~/login.aspx");
            }
            id = Convert.ToInt32(Request.QueryString["id"]);

            var user = service.RetornaUsuario(Session["Login"].ToString());
            if (!user.Modulos.Any(x => x.id_modulo == 3))
            {
                Response.Redirect("~/AcessoNegado.aspx");
            }

            var dirimp = new DirectoryInfo(ConfigurationManager.AppSettings["LocalDir"].ToString() + "//Files//Indexar");
            var listfiles = dirimp.GetFiles("*.pdf", SearchOption.AllDirectories);
            StringBuilder str = new StringBuilder();
            str.Append("<ol>");
            foreach (var item in listfiles)
            {
                str.Append("<li><a runat='server' href='../Documentos/Indexar?file=" + item.Name + "'>" + item.Name + "</a></li>");
            }
            str.Append("</ol>");
            ArquivosIndexar.Text = str.ToString();
        }
    }
}