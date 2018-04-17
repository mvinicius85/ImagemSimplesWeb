using ImagemSimplesWeb.Application.Interface;
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
    }
}