using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImagemSimplesWeb.Documentos
{
    public partial class ListaIndexar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dirimp = new DirectoryInfo(ConfigurationManager.AppSettings["LocalDir"].ToString() + "//Files//Indexar");
            var listfiles = dirimp.GetFiles("*.pdf", SearchOption.AllDirectories);
            StringBuilder str = new StringBuilder();
            str.Append("<ol>");
            foreach (var item in listfiles)
            {
                str.Append("<li><a runat='server' href='../Documentos/Indexar?file=" + item.Name + "'>" + item.Name + "</a></li>");
            }
            str.Append("</ol>");
            ArquivosIndexar.Text = str.ToString();
        }
    }
}