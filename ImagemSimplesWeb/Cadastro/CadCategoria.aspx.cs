using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImagemSimplesWeb.Cadastro
{
    public partial class CadCategoria : System.Web.UI.Page
    {
        private readonly ICadastroAppService service;
        private static int id;
        public CadCategoria()
        {
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
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
            MontaTela();
            PreencheTela();
        }

        private void PreencheTela()
        {
            var cat = service.PesquisaCategoria(id);
            lblidCategoria.Text = cat.id_Oper.ToString();
            ddlMenus.SelectedValue = cat.Dependencia.ToString();
            txtDescricao.Text = cat.Descricao.ToString();
            if (!String.IsNullOrEmpty(cat.ExisteMDB))
            {
                chkExisteMDB.Checked = cat.ExisteMDB.ToString() == "SIM" ? true : false;
            }
            else
            {
                chkExisteMDB.Checked = false;
            }
            txtPathImagens.Text = cat.PATHIMAGENS != null ? cat.PATHIMAGENS : "";
        }

        private void MontaTela()
        {
            var frmcadcategoria = service.PreencheTela();
            foreach (var item in frmcadcategoria.Menus)
            {
                ddlMenus.Items.Add(new ListItem(item.Descricao, item.id_Oper.ToString()));
            }
           
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {


            var cat = new User_MenuViewModel(
                Convert.ToInt32(lblidCategoria.Text),
                Convert.ToInt32(Request.Form["ctl00$CadCategoria$ddlMenus"]),
                Request.Form["ctl00$CadCategoria$txtDescricao"].ToString(),
                Request.Form["ctl00$CadCategoria$chkExisteMDB"] == "on" ? "SIM" : "NÃO",
                Request.Form["ctl00$CadCategoria$txtPathImagens"].ToString()
                );

            var ret = service.AlteraCategoria(cat);
            if (ret == "S")
            {
                Response.Redirect("Categoria.aspx");
            }
        }
    }
}