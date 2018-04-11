using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
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


        }

        protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            // Display the text of the menu item selected by the user.
            Session["dir"] = e.Item.Value;
            var item = (MenuItem)e.Item;
            if (item.ChildItems.Count > 0)
            {
                return;
            }
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

        protected List<User_MenuViewModel> CriaMenu()
        {
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            var appcadastro = container.GetInstance<ICadastroAppService>();
            var menus = appcadastro.BuscaMenu();
            menus = menus.OrderByDescending(x => x.id_Oper).ToList();
            return menus.Where(x => x.submenu.Count > 0).ToList();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            var x = e;
        }
    }
}