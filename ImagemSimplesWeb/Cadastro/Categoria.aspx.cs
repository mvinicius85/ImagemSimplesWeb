using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Application.ViewModels;
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
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            var service = container.GetInstance<ICadastroAppService>();


            var user = service.RetornaUsuario(Session["Login"].ToString());
            if (!user.Modulos.Any(x => x.id_modulo == 1))
            {
                Response.Redirect("~/AcessoNegado.aspx");
            }

            var categorias = service.ListaCategorias();
            GridCategorias.DataSource = categorias;
            GridCategorias.DataBind();
            if (ddlArmazenaImagens.Items.Count == 0)
            {
                ddlArmazenaImagens.Items.Add(new ListItem("Todos", "0"));
                ddlArmazenaImagens.Items.Add(new ListItem("Sim", "1"));
                ddlArmazenaImagens.Items.Add(new ListItem("Não", "2"));
            }

        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton button = sender as ImageButton;
            var x = button.CommandArgument;
            Response.Redirect("CadCategoria.aspx?id=" + x.ToString());
        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            GridCategorias.PageIndex = 0;
            Session["descMenu"] = Request.Form["ctl00$Categoria$txtDescricao"].ToString();
            Session["nomeMenu"] = Request.Form["ctl00$Categoria$txtNome"].ToString();
            Session["armazMenu"] = Request.Form["ctl00$Categoria$ddlArmazenaImagens"].ToString();

            RecarregarGrid();
        }
        void RecarregarGrid()
        {
            var filtro = new frmCategoriasViewModel(
                Session["descMenu"] == null ? "" : Session["descMenu"].ToString(),
                Session["nomeMenu"] == null ? "" : Session["nomeMenu"].ToString(),
                 Session["armazMenu"] == null ? "" : Session["armazMenu"].ToString()
                );
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            var service = container.GetInstance<ICadastroAppService>();
            var categorias = service.BuscarCategoria(filtro);
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