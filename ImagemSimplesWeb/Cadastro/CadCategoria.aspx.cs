﻿using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Application.ViewModels;
using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImagemSimplesWeb.Cadastro
{
    public partial class CadCategoria : System.Web.UI.Page
    {
        private readonly ICadastroAppService service;
        private static int id;
        private static List<USER_CAT_ATRIBUTOSViewModel> atributos;
        public CadCategoria()
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
            MontaTela();
            if (!this.IsPostBack)
            {
                PreencheTela();
            }
        }

        private void PreencheTela()
        {
            if (id == 0)
            {
                txtNomeAtrib.Enabled = false;
                txtTituloAtrib.Enabled = false;
                BtnAdd.Enabled = false;
                return;
            }
            var cat = service.PesquisaCategoria(id);
            lblidCategoria.Text = cat.id_Oper.ToString();
            ddlMenus.SelectedValue = cat.Dependencia.ToString();
            txtDescricao.Text = cat.Descricao.ToString();
            txtNome.Text = cat.Nome.ToString();
            txtNivel.Text = cat.Nivel;
            ddlTipoArquivo.SelectedValue = cat.id_tipo_arquivo == null ? "0" : cat.id_tipo_arquivo.ToString();
            chkAtivo.Checked = cat.ind_ativo;
            if (!String.IsNullOrEmpty(cat.ExisteMDB))
            {
                chkExisteMDB.Checked = cat.ExisteMDB.ToString().Trim() == "SIM" ? true : false;
            }
            else
            {
                chkExisteMDB.Checked = false;
            }
            txtPathImagens.Text = cat.PATHIMAGENS != null ? cat.PATHIMAGENS : "";

            atributos = cat.Atributos;
            gridAtributos.DataSource = cat.Atributos;
            gridAtributos.DataBind();


            if (cat.PossuiDocumentos)
            {
                lblMsgErro.Text = "Não será possível alterar os atributos desta categoria pois ela possui documentos vinculados";
                lblMsgErro.Visible = true;
                gridAtributos.Enabled = false;
                BtnAdd.Enabled = false;
                txtNomeAtrib.Enabled = false;
                txtTituloAtrib.Enabled = false;
            }
        }

        private void MontaTela()
        {
            var frmcadcategoria = service.PreencheTela();

            var user = service.RetornaUsuario(Session["Login"].ToString());
            if (!user.Modulos.Any(x => x.id_modulo == 1))
            {
                Response.Redirect("~/AcessoNegado.aspx");
            }

            if (ddlMenus.Items.Count == 0)
            {
                foreach (var item in frmcadcategoria.Menus.Where(y => y.ExisteMDB.Trim().ToUpper() == "NAO").OrderBy(x => x.id_Oper).ToList())
                {
                    ddlMenus.Items.Add(new ListItem(item.DescNivel, item.id_Oper.ToString()));
                }
            }

            if (ddlTipoArquivo.Items.Count == 0)
            {
                foreach (var item in frmcadcategoria.TiposArquivo.OrderBy(x => x.id_tipo_arquivo).ToList())
                {
                    ddlTipoArquivo.Items.Add(new ListItem(item.descricao, item.id_tipo_arquivo.ToString()));
                }
            }


        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {


            var cat = new User_MenuViewModel(
                Convert.ToInt32(lblidCategoria.Text == "" ? "0" : lblidCategoria.Text),
                Convert.ToInt32(Request.Form["ctl00$CadCategoria$ddlMenus"]),
                txtNome.Text,
                txtDescricao.Text,
                txtNivel.Text,
                chkExisteMDB.Checked ? "SIM" : "NAO",
                txtPathImagens.Text,
                Convert.ToInt32(Request.Form["ctl00$CadCategoria$ddlTipoArquivo"]),
                chkAtivo.Checked
                );

            //cat.Atributos = RetornaListaAtrib();
            cat.Atributos = atributos;
            string ret = "";
            if (cat.id_Oper == 0)
            {
                ret = service.InserirCategoria(cat);
            }
            else
            {
                ret = service.AlteraCategoria(cat);
            }
            if (ret == "S")
            {
                Response.Redirect("Categoria.aspx");
            }
            else
            {
                lblMsgErro.Text = ret;
                lblMsgErro.Visible = true;
            }
        }

        protected void Unnamed_Click(object sender, ImageClickEventArgs e)
        {
            //RemontaTela();
            ImageButton button = sender as ImageButton;
            var nomeatrib = button.CommandArgument;
            //foreach (GridViewRow row in gridAtributos.Rows)
            //{
            //    var nome = (Label)row.Cells[2].Controls[1];
            //    var header = (Label)row.Cells[3].Controls[1];
            //    var item = new USER_CAT_ATRIBUTOSViewModel(
            //        Convert.ToInt32(lblidCategoria.Text),
            //        nome.Text, header.Text);
            //    atributos.Add(item);
            //}
            atributos.Remove(atributos.Where(x => x.NomeAtributo == nomeatrib).FirstOrDefault());
            gridAtributos.DataSource = atributos.ToList();
            gridAtributos.DataBind();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            //RemontaTela();
            //var cat = RetornaListaAtrib();

            var y = atributos.Where(x => x.NomeAtributo == txtNomeAtrib.Text).FirstOrDefault();
            if (y != null)
            {
                return;
            }


            //cat.Add(new USER_CAT_ATRIBUTOSViewModel(Convert.ToInt32(lblidCategoria.Text == "" ? "0" : lblidCategoria.Text), txtNomeAtrib.Text, txtTituloAtrib.Text));
            atributos.Add(new USER_CAT_ATRIBUTOSViewModel(Convert.ToInt32(lblidCategoria.Text == "" ? "0" : lblidCategoria.Text), txtNomeAtrib.Text, txtTituloAtrib.Text));
            gridAtributos.DataSource = atributos.ToList();
            gridAtributos.DataBind();
        }

        private List<USER_CAT_ATRIBUTOSViewModel> RetornaListaAtrib()
        {
            var cat = new List<USER_CAT_ATRIBUTOSViewModel>();
            foreach (GridViewRow row in gridAtributos.Rows)
            {
                var nome = (Label)row.Cells[2].Controls[1];
                var header = (Label)row.Cells[3].Controls[1];
                var item = new USER_CAT_ATRIBUTOSViewModel(
                    Convert.ToInt32(lblidCategoria.Text == "" ? "0" : lblidCategoria.Text),
                    nome.Text, header.Text);
                cat.Add(item);
            }

            return cat;
        }

        //private void RemontaTela()
        //{
        //    ddlMenus.SelectedValue = Request.Form["ctl00$CadCategoria$ddlMenus"].ToString().TrimEnd();
        //    txtNome.Text = Request.Form["ctl00$CadCategoria$txtNome"].ToString().TrimEnd();
        //    txtDescricao.Text = Request.Form["ctl00$CadCategoria$txtDescricao"].ToString().TrimEnd();
        //    txtNivel.Text = Request.Form["ctl00$CadCategoria$txtNivel"].ToString().TrimEnd();
        //    chkExisteMDB.Checked = Request.Form["ctl00$CadCategoria$chkExisteMDB"] == "on" ? true : false;
        //    txtPathImagens.Text = Request.Form["ctl00$CadCategoria$txtPathImagens"].ToString().TrimEnd();
        //    ddlTipoArquivo.SelectedValue = Request.Form["ctl00$CadCategoria$ddlTipoArquivo"].ToString().TrimEnd();
        //}

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cadastro/Categoria.aspx");
        }

        [WebMethod]
        public static bool ValidaDependencia(string codcategoria)
        {
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            var service = container.GetInstance<ICadastroAppService>();
            var retorno = service.ValidaCategoria(codcategoria);
            return retorno;
        }
    }
}