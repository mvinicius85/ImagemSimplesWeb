using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Application.ViewModels;
using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImagemSimplesWeb.Cadastro
{
    public partial class Usuarios : System.Web.UI.Page
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
            var usuarios = service.ListaUsuarios();
            GridUsuarios.DataSource = usuarios;
            GridUsuarios.DataBind();
        }

        protected void BtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton button = sender as ImageButton;
            var x = button.CommandArgument;
            Response.Redirect("CadUsuario.aspx?id=" + x.ToString());
        }

        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadUsuario.aspx");
        }

        protected void BtnExcluir_Click(object sender, ImageClickEventArgs e)
        {

        }

        public void RecarregarGrid()
        {
            var nome = Session["usuNome"] == null ? "" : Session["usuNome"];
            var dep = Session["usuDep"] == null ? "" : Session["usuDep"];
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.AppSettings["conn"]);
            var service = container.GetInstance<ICadastroAppService>();
            var filtro = new User_CadastroViewModel(nome.ToString(), dep.ToString());
            var usuarios = service.FiltrarUsuarios(filtro);
            GridUsuarios.DataSource = usuarios;
            GridUsuarios.DataBind();
        }

        protected void GridUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridUsuarios.PageIndex = e.NewPageIndex;
            RecarregarGrid();
        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            GridUsuarios.PageIndex = 0;
            Session["usuNome"] = Request.Form["ctl00$Usuarios$txtNome"].ToString();
            Session["usuDep"] = Request.Form["ctl00$Usuarios$txtDepartamento"].ToString();
            RecarregarGrid();
        }
    }
}