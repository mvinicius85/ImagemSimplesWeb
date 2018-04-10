using ImagemSimplesWeb.Application.Interface;
using System;
using System.Collections.Generic;
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


    }
}