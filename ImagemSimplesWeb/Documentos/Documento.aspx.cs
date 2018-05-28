﻿using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Application.ViewModels;
using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImagemSimplesWeb.Documentos
{
    public partial class Documento : System.Web.UI.Page
    {
        public readonly List<User_MenuViewModel> menus = new List<User_MenuViewModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var login = Session["Login"];
            if (login == null)
            {
                Response.Redirect("~/login.aspx");
            }

            var id = Convert.ToInt32(Request.QueryString["idoper"]);
            if (id > 0)
            {
                Session["idoper"] = id;
                MontaGrid(id);
                PreencheGrid(id);
            }
        }

        private void MontaGrid(int id)
        {
            if (griddocumentos.Columns.Count > 0)
            {
                return;
            }

            var col1 = new BoundField();
            col1.DataField = "imagem";
            col1.HeaderText = "Imagem";
            griddocumentos.Columns.Add(col1);

            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            var menuservice = container.GetInstance<ICadastroAppService>();
            var atrib = menuservice.ListarAtributos(id);

            StringBuilder table = new StringBuilder();
            foreach (var item in atrib)
            {
                var col2 = new BoundField();
                col2.DataField = item.NomeAtributo;
                col2.HeaderText = item.TituloAtributo;
                griddocumentos.Columns.Add(col2);

                table.Append("<tr>");
                table.Append("<td class='tdText'>");
                table.Append("<span>" + item.TituloAtributo + ": </span>");
                table.Append("</td>");
                table.Append("<td>");
                table.Append("<input type='text' id='txt" + item.Ordem + "'>");
                table.Append("</td>");
                table.Append("</tr>");
            }
            TableSearch.Text = table.ToString();

        }

        //protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
        //{
        //    // Display the text of the menu item selected by the user.
        //    Session["dir"] = e.Item.Value;
        //    var item = (MenuItem)e.Item;
        //    if (item.ChildItems.Count > 0)
        //    {
        //        return;
        //    }
        //    if (Session["dir"] == null)
        //    {
        //        return;
        //    }
        //    LoadGrid(Session["dir"].ToString());
        //}

        protected void griddocumento_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "Duplo clique na linha para abrir documento em nova aba.";
                // e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.griddocumentos, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["onclick"] = "openFile(this)";
                e.Row.Attributes["ondblclick"] = "openPdfNewTab(this)";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = griddocumentos.SelectedRow.RowIndex;
            string name = griddocumentos.SelectedRow.Cells[0].Text;

            //Process.Start(Session["dir"].ToString() + "\\" + name);
            string pdfPath = Session["dir"].ToString() + "\\" + name;
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(pdfPath);
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", buffer.Length.ToString());
            Response.BinaryWrite(buffer);
        }

        protected void griddocumentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var id = Convert.ToInt32(Request.QueryString["idoper"]);
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());

            var menuserivce = container.GetInstance<ICadastroAppService>();
            var categoria = menuserivce.PesquisaCategoria(Convert.ToInt32(id));

            var query = RetornaQuery(Convert.ToInt32(categoria.id_tipo_arquivo));

            griddocumentos.PageIndex = e.NewPageIndex;
            LoadGrid(Session["dir"].ToString(), query);
        }

        private string RetornaQuery(int id_tipo_arquivo)
        {
            string query = "";

            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            var menuservice = container.GetInstance<ICadastroAppService>();
            var atrib = menuservice.ListarAtributos(Convert.ToInt32(Request.QueryString["idoper"]));
            foreach (var item in atrib)
            {
                var x = Request.QueryString[item.Ordem.ToString()];
                switch (id_tipo_arquivo)
                {
                    case 1:
                        if (!String.IsNullOrEmpty(x))
                        {
                            query = query.Length > 0 ? query + " and " : "";
                            query = query + item.NomeAtributo + " like '%" + x + "%' ";
                        }
                        break;
                    case 3:
                        if (!String.IsNullOrEmpty(x))
                        {
                            
                            query = query.Length > 0 ? query + " or " : "";
                            query = query + "(";
                            query = query + "uca.nomeatributo = '" + item.NomeAtributo + "' AND uda.valor like '%" + x + "%' ";
                            query = query + ")";
                        }
                        break;
                }

            }

            return query;
        }

        private void LoadGrid(string dir, string query)
        {


            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());


            var dirimp = new DirectoryInfo(HttpRuntime.AppDomainAppPath + dir);
            var listfiles = dirimp.GetFiles("*.mdb", SearchOption.AllDirectories);
            //Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            //container.GetInstance<ImagemSimplesWeb.Documento.Infra.Data.Contexto.Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.AppSettings["conn"]);
            var appservice = container.GetInstance<IArquivoAppService>();
            var griddatasource = appservice.AbreArquivo(listfiles.FirstOrDefault().FullName, query);
            griddocumentos.DataSource = griddatasource;
            griddocumentos.DataBind();
        }

        protected List<User_MenuViewModel> CriaMenu()
        {
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            var appcadastro = container.GetInstance<ICadastroAppService>();
            var menus = appcadastro.BuscaMenu();
            menus = menus.OrderByDescending(x => x.id_Oper).ToList();
            return menus.Where(x => x.submenu.Count > 0).ToList();
        }


        public void PreencheGrid(int idoper)
        {
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());

            var menuserivce = container.GetInstance<ICadastroAppService>();
            var user = menuserivce.RetornaUsuario(Session["login"].ToString());

            if (!user.Acessos.Any(x => x.id_oper == idoper))
            {
                txtMsgAcessoProibido.Text = "Você não possui acesso a esta categoria.";
                return;
            }

            // string pathmenu = menuserivce.RetornaCaminhoImgens(Convert.ToInt32(idoper));
            var categoria = menuserivce.PesquisaCategoria(Convert.ToInt32(idoper));
            var query = RetornaQuery(Convert.ToInt32(categoria.id_tipo_arquivo));
            if (categoria.id_tipo_arquivo == 1)
            {
                Session["dir"] = categoria.PATHIMAGENS;
                LoadGrid(categoria.PATHIMAGENS, query);
            }
            else if (categoria.id_tipo_arquivo == 3)
            {

                LoadGridPostgres(idoper, query);
            }


        }

        private void LoadGridPostgres(int idoper, string query)
        {
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            var docservice = container.GetInstance<IDocumentoAppService>();
            var ds = docservice.RetornaDocumentos(idoper, query);
            griddocumentos.DataSource = ds;
            griddocumentos.DataBind();
        }

        [WebMethod(EnableSession = true)]
        public static string getPath()
        {
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            var menuserivce = container.GetInstance<ICadastroAppService>();

            var categoria = menuserivce.PesquisaCategoria(Convert.ToInt32(HttpContext.Current.Session["idoper"]));
            if (categoria.id_tipo_arquivo == 1)
            {
                return HttpContext.Current.Session["dir"].ToString();
            }
            else if (true)
            {
                return "";
            }

        }

    }
}