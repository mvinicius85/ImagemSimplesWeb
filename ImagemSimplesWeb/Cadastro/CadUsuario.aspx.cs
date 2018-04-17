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
    public partial class CadUsuario : System.Web.UI.Page
    {
        private readonly ICadastroAppService service;
        private static int id;

        public CadUsuario()
        {
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.AppSettings["conn"]);
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
            PreencheTela();
        }

        private void PreencheTela()
        {
            var usuario = service.RetornaUsuario(id);
            lblidUsuario.Text = usuario.id_user.ToString();
            txtCodigo.Text = usuario.codigo;
            txtSenha.Text = usuario.Senha;
            txtNome.Text = usuario.Nome;
            txtDepartamento.Text = usuario.Depto;
            txtCadastro.Text = usuario.Data;
            txtDtInicio.Text = usuario.DataInicio;
            txtTelefone.Text = usuario.Tel1;
            txtTelRes.Text = usuario.Tel2;
            txtTelCel.Text = usuario.Tel3;
            txtEmail.Text = usuario.Email;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            
            var usuario = new User_CadastroViewModel(
                Convert.ToInt32(lblidUsuario.Text),
                Request.Form["ctl00$CadUsuario$txtSenha"].ToString(),
                Request.Form["ctl00$CadUsuario$txtCodigo"].ToString(),
                Request.Form["ctl00$CadUsuario$txtNome"].ToString(),
                Request.Form["ctl00$CadUsuario$txtDepartamento"].ToString(),
                Request.Form["ctl00$CadUsuario$txtCadastro"].ToString(),
                Request.Form["ctl00$CadUsuario$txtDtInicio"].ToString(),
                Request.Form["ctl00$CadUsuario$txtTelefone"].ToString(),
                Request.Form["ctl00$CadUsuario$txtTelRes"].ToString(),
                Request.Form["ctl00$CadUsuario$txtTelCel"].ToString(),
                Request.Form["ctl00$CadUsuario$txtEmail"].ToString(), true);
            var ret = service.AlterarUsuario(usuario);
            if (ret == "S")
            {
                Response.Redirect("Usuarios.aspx");
            }
            //var user = new User_CadastroViewModel(
            //    Convert.ToInt32(lblidCategoria.Text),
            //    Convert.ToInt32(Request.Form["ctl00$CadCategoria$ddlMenus"]),
            //    Request.Form["ctl00$CadCategoria$txtDescricao"].ToString(),
            //    Request.Form["ctl00$CadCategoria$chkExisteMDB"] == "on" ? "SIM" : "NÃO",
            //    Request.Form["ctl00$CadCategoria$txtPathImagens"].ToString()
            //    );

            //var ret = service.AlteraCategoria(user);
            //if (ret == "S")
            //{
            //    Response.Redirect("Categoria.aspx");
            //}
        }
    }
}