using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImagemSimplesWeb.Cadastro
{
    public partial class Categoria : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            var login = Session["Login"];
            if (login == null)
            {
                Response.Redirect("~/login.aspx");
            }

            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.AppSettings["conn"]);
            var service = container.GetInstance<ICadastroAppService>();
            var categorias = service.ListaCategorias();
            GridCategorias.DataSource = categorias;
            GridCategorias.DataBind();
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton button = sender as ImageButton;
            var x = button.CommandArgument;
            Response.Redirect("CadCategoria.aspx?id=" + x.ToString());
        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            GridCategorias.PageIndex = 1;
            Session["descMenu"] = Request.Form["ctl00$Categoria$txtDescricao"].ToString();
            RecarregarGrid();
        }
        void RecarregarGrid()
        {
            var desc = Session["descMenu"] == null ? "" : Session["descMenu"];
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.AppSettings["conn"]);
            var service = container.GetInstance<ICadastroAppService>();
            var categorias = service.BuscarCategoria(desc.ToString());
            GridCategorias.DataSource = categorias;
            GridCategorias.DataBind();
        }

        protected void GridCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridCategorias.PageIndex = e.NewPageIndex;
            RecarregarGrid();
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadCategoria.aspx");
        }
    }
}