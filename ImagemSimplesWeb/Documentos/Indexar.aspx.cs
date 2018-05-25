using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Application.ViewModels;
using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImagemSimplesWeb.Documentos
{
    public partial class Indexar : System.Web.UI.Page
    {
        private readonly ICadastroAppService service;
        string file;
        int id;
        public Indexar()
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

            var user = service.RetornaUsuario(Session["Login"].ToString());
            if (!user.Modulos.Any(x => x.id_modulo == 3))
            {
                Response.Redirect("~/AcessoNegado.aspx");
            }

            file = Request.QueryString["file"].ToString();
            pdfFrame.Src = "\\Files\\Indexar\\" + file;


            //var frmcadcategoria = service.PreencheTela();
            if (ddlCategorias.Items.Count == 0)
            {
                var frmcadcategoria = service.CategoriasDocumentos();
                foreach (var item in frmcadcategoria.OrderBy(x => x.Nivel).ToList())
                {
                    ddlCategorias.Items.Add(new ListItem(item.DescNivel, item.id_Oper.ToString()));
                }
            }

        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = ddlCategorias.SelectedValue.ToString();
            CriaFormIndexacao(Convert.ToInt32(x));
        }

        private void CriaFormIndexacao(int v)
        {
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            var menuservice = container.GetInstance<ICadastroAppService>();
            var atrib = menuservice.ListarAtributos(v);

            StringBuilder table = new StringBuilder();
            table.Append("<input type='hidden' id='qtdeatb' value='" + atrib.Count + "' />");
            table.Append("<input type='hidden' id='idcateg' value='" + v.ToString() + "' />");
            table.Append("<input type='hidden' id='nmfile' value='" + file + "' />");
            foreach (var item in atrib)
            {

                table.Append("<tr>");
                table.Append("<td>");
                table.Append("<span>" + item.TituloAtributo + ": </span>");
                table.Append("</td>");
                table.Append("<td>");
                table.Append("<input type='text' runat='server' id='txt" + item.Ordem + "'>");
                table.Append("</td>");
                table.Append("</tr>");
            }
            TableAtributos.Text = table.ToString();
        }

        //protected void BtnSalvar_Click(object sender, EventArgs e)
        //{
        //    var x = ddlCategorias.SelectedValue.ToString();

        //    var container = new SimpleInjector.Container();
        //    Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
        //    container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
        //    var menuservice = container.GetInstance<ICadastroAppService>();
        //    var atrib = menuservice.ListarAtributos(Convert.ToInt32(x));
        //    string[] atributos = new string[atrib.Count];
        //    foreach (var item in atrib)
        //    {
        //        atributos[Convert.ToInt32(item.Ordem)] = Request.Form["ctl00$CadCategoria$txt" + item.Ordem.ToString()].ToString();

        //    }
        //}

        [WebMethod]
        public static string SalvarIndexacao(string atribs, string idcateg, string nmfile)
        {

            var x = atribs.Split(';');
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            var menuservice = container.GetInstance<ICadastroAppService>();
            var atrib = menuservice.ListarAtributos(Convert.ToInt32(idcateg));

            var doc = new User_Documentos_ImagemViewModel(0, Convert.ToInt32(idcateg), 1, "Teste", "");
            for (int i = 1; i < x.Length; i++)
            {
                int idatrib = atrib.Where(y => y.Ordem == i).FirstOrDefault().id_cat_atrib;
                doc.atributos.Add(new User_Documentos_AtributosViewModel(0, 23, idatrib, x[i]));
            }

            var docservice = container.GetInstance<IDocumentoAppService>();
            var ret = docservice.InsereDocumento(doc, nmfile);
            return ret;


        }
    }
}