using ImagemSimplesWeb.Application.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImagemSimplesWeb.Documentos
{
    public partial class Documento : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            var login = Session["Login"];
            if (login == null)
            {
                Response.Redirect("~/login.aspx");
            }

            if (!this.IsPostBack)
            {
                //string path = @"C:\Camara Municipal de Itapevi\Documentos 1995\Secretaria Executiva\Processo Legislativo\PROCESSO LEGISLATIVO.MDB";
                //string pathfile = @"C:\Camara Municipal de Itapevi\Documentos 1995\Secretaria Executiva\Processo Legislativo\";
                //string connectionName = "Provider=Microsoft.Jet.OLEDB.4.0;"
                //  + "Data Source= " + path + " ;";


                //var container = new SimpleInjector.Container();
                //Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
                //var teste = container.GetInstance<IArquivoAppService>();
                //var teste2 = teste.AbreArquivo(connectionName);
                //griddocumentos.DataSource = teste2;
                //griddocumentos.DataBind();

                var container = new SimpleInjector.Container();
                Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
                var appcadastro = container.GetInstance<ICadastroAppService>();
                var menus = appcadastro.BuscaMenu();
                menus = menus.OrderByDescending(x => x.id_Oper).ToList();
                foreach (var item in menus)
                {
                    if (item.Dependencia > 0)
                    {
                        menus.Where(y => y.id_Oper == item.Dependencia).FirstOrDefault().submenu.Add(item);
                    }
                }
                var final = menus.Where(x => x.Dependencia == 0).OrderBy(y => y.id_Oper).ToList();


                foreach (var f in final)
                {
                    var submenu = new MenuItem(f.Descricao);
                    if (f.submenu.Count > 0)
                    {
                        foreach (var g in f.submenu)
                        {
                            var submenu2 = new MenuItem(g.Descricao);
                            if (g.submenu.Count > 0)
                            {
                                foreach (var h in g.submenu)
                                {
                                    var submenu3 = new MenuItem(h.Descricao, h.PATHIMAGENS);
                                    submenu2.ChildItems.Add(submenu3);
                                }
                            }
                            submenu.ChildItems.Add(submenu2);
                        }
                    }
                    menu.Items.Add(submenu);

                }
            }
        }

        protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            // Display the text of the menu item selected by the user.

            Session["dir"] = e.Item.Value;
            if (Session["dir"] == null)
            {
                return;
            }
            LoadGrid(Session["dir"].ToString());

        }

        protected void griddocumento_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.griddocumentos, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = griddocumentos.SelectedRow.RowIndex;
            // string name = griddocumentos.SelectedRow.Cells[12].Text;
            string name = (griddocumentos.SelectedRow.FindControl("path_imagem") as Label).Text;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
            name = name.Replace("\\\\192.168.0.43\\D$", "\\Files\\");
           
            Process.Start(name);
        }

        protected void griddocumentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            griddocumentos.PageIndex = e.NewPageIndex;
            LoadGrid(Session["dir"].ToString());
        }

        private void LoadGrid(string dir)
        {

            var dirimp = new DirectoryInfo(dir);
            var listfiles = dirimp.GetFiles("*.mdb", SearchOption.AllDirectories);
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            var appservice = container.GetInstance<IArquivoAppService>();
            var griddatasource = appservice.AbreArquivo(listfiles.FirstOrDefault().FullName);
            griddocumentos.DataSource = griddatasource;
            griddocumentos.DataBind();
        }
    }
}