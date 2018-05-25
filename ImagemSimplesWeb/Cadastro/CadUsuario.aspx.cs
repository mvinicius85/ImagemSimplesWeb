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

            var user = service.RetornaUsuario(Session["Login"].ToString());
            if (!user.Modulos.Any(x => x.id_modulo == 2))
            {
                Response.Redirect("~/AcessoNegado.aspx");
            }

            id = Convert.ToInt32(Request.QueryString["id"]);
            PreencheTela();
        }

        private void PreencheTela()
        {
            if (id == 0)
            {
                ddlMenus.Enabled = false;
                BtnAdd.Enabled = false;
                return;
            }
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
            if (GridAcessos.Rows.Count == 0)
            {
                GridAcessos.DataSource = usuario.Acessos;
                GridAcessos.DataBind();
            }

            foreach (var mod in usuario.Modulos)
            {
                if (mod.id_modulo == 1)
                {
                    chkCategorias.Checked = true;
                }
                if (mod.id_modulo == 2)
                {
                    chkUsuarios.Checked = true;
                }
                if (mod.id_modulo == 3)
                {
                    chkIndexar.Checked = true;
                }
            }


            var frmcadcategoria = service.PreencheTela();
            foreach (var item in frmcadcategoria.Menus.OrderBy(x => x.Nivel).ToList())
            {
                ddlMenus.Items.Add(new ListItem(item.DescNivel, item.id_Oper.ToString()));
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            var usuario = new User_CadastroViewModel(
                Convert.ToInt32(String.IsNullOrWhiteSpace(lblidUsuario.Text) ? "0" : lblidUsuario.Text),
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

            if (Request.Form["ctl00$CadUsuario$chkUsuarios"] != null)
            {
                usuario.Modulos.Add(new User_ModulosViewModel(2, "Usuarios"));
            }

            if (Request.Form["ctl00$CadUsuario$chkCategorias"] != null)
            {
                usuario.Modulos.Add(new User_ModulosViewModel(1, "Categorias"));
            }

            if (Request.Form["ctl00$CadUsuario$chkIndexar"] != null)
            {
                usuario.Modulos.Add(new User_ModulosViewModel(3, "Indexar"));
            }

            string ret = "";
            if (usuario.id_user == 0)
            {
                ret = service.InserirUsuario(usuario);
            }
            else
            {
                usuario.Acessos = RetornaListaAcessos();
                ret = service.AlterarUsuario(usuario);
            }

            if (ret == "S")
            {
                Response.Redirect("Usuarios.aspx");
            }
            else
            {
                lblMsgErro.Text = ret;
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

        protected void BtnExcluir_Click(object sender, ImageClickEventArgs e)
        {
            RemontaTela();
            ImageButton button = sender as ImageButton;
            var idoper = Convert.ToInt32(button.CommandArgument);
            var acessos = new List<AcessosViewModel>();
            foreach (GridViewRow row in GridAcessos.Rows)
            {
                var id = (Label)row.Cells[0].Controls[1];
                var desc = (Label)row.Cells[1].Controls[1];
                var nivel = (Label)row.Cells[2].Controls[1];
                var item = new AcessosViewModel(Convert.ToInt32(id.Text), desc.Text.TrimEnd(), nivel.Text);
                acessos.Add(item);
            }
            acessos.Remove(acessos.Where(x => x.id_oper == idoper).FirstOrDefault());
            GridAcessos.DataSource = acessos.ToList();
            GridAcessos.DataBind();
        }

        private List<AcessosViewModel> RetornaListaAcessos()
        {
            var cat = new List<AcessosViewModel>();
            foreach (GridViewRow row in GridAcessos.Rows)
            {
                var id = (Label)row.Cells[0].Controls[1];
                var desc = (Label)row.Cells[1].Controls[1];
                var nivel = (Label)row.Cells[2].Controls[1];
                var item = new AcessosViewModel(Convert.ToInt32(id.Text),desc.Text.TrimEnd(),nivel.Text);
                cat.Add(item);
            }
            return cat;
        }

        private void RemontaTela()
        {
            //ddlMenus.SelectedIndex = 0;

            txtSenha.Text = Request.Form["ctl00$CadUsuario$txtSenha"].ToString();
            txtCodigo.Text = Request.Form["ctl00$CadUsuario$txtCodigo"].ToString();
            txtNome.Text = Request.Form["ctl00$CadUsuario$txtNome"].ToString();
            txtDepartamento.Text = Request.Form["ctl00$CadUsuario$txtDepartamento"].ToString();
            txtCadastro.Text = Request.Form["ctl00$CadUsuario$txtCadastro"].ToString();
            txtDtInicio.Text = Request.Form["ctl00$CadUsuario$txtDtInicio"].ToString();
            txtTelefone.Text = Request.Form["ctl00$CadUsuario$txtTelefone"].ToString();
            txtTelRes.Text = Request.Form["ctl00$CadUsuario$txtTelRes"].ToString();
            txtTelCel.Text = Request.Form["ctl00$CadUsuario$txtTelCel"].ToString();
            txtEmail.Text = Request.Form["ctl00$CadUsuario$txtEmail"].ToString();

        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            RemontaTela();
            var acessos = RetornaListaAcessos();

            if (ddlMenus.SelectedIndex > 0)
            {
                var selec = service.PesquisaCategoria(Convert.ToInt32(ddlMenus.SelectedValue));
                acessos.Add(new AcessosViewModel(selec.id_Oper, selec.Descricao, selec.Nivel));
            }
            GridAcessos.DataSource = acessos;
            GridAcessos.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cadastro/Usuarios.aspx");
        }
    }
}