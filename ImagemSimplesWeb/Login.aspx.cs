using ImagemSimplesWeb.Application.Interface;
using ImagemSimplesWeb.Application.Model;
using ImagemSimplesWeb.Documento.Infra.Data.Contexto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImagemSimplesWeb
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly ICadastroAppService service;
        public Login()
        {
            var container = new SimpleInjector.Container();
            Infra.CrossCutting.IoC.BootStrapper.RegisterServices(container);
            container.GetInstance<Imagem_ItapeviContext>().ChangeConnection(ConfigurationManager.ConnectionStrings["PgProdutos"].ToString());
            service = container.GetInstance<ICadastroAppService>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var key = Request.QueryString["key"];
            var user = Request.QueryString["u"];
            var pass = Request.QueryString["p"];

            if (key != null)
            {
                ValidarKey(key);
                return;
            }

            if (user != null && pass != null)
            {
                ValidarUser(user, pass);
                return;
            }
        }

        private void ValidarUser(string param1, string param2)
        {
            var endpoint = $"http://192.168.1.32/Encrypt/api/Decrypt/{param1},{param2}";
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(endpoint).Result;
                if (!response.IsSuccessStatusCode)
                {

                }
                else
                {
                    //await context.PostAsync("Aguarde um momento por favor.");
                    var json = response.Content.ReadAsStringAsync();
                    //var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json.Result);
                    var r = JsonConvert.DeserializeObject<User>(json.Result);
                    Logar(r.Login, r.Senha);
                }


            }
        }

        private void ValidarKey(string key)
        {
            key = key.Replace("||", " ");
            var keys = key.Split(' ');
            var user = new User(keys[0].ToString(), keys[1].ToString());
            var endpoint = $"http://192.168.1.32/Encrypt/api/Decrypt/{user.Login},{user.Senha}";
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(endpoint).Result;
                if (!response.IsSuccessStatusCode)
                {

                }
                else
                {
                    //await context.PostAsync("Aguarde um momento por favor.");
                    var json = response.Content.ReadAsStringAsync();
                    //var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json.Result);
                    var r = JsonConvert.DeserializeObject<User>(json.Result);
                    Logar(r.Login, r.Senha);
                }


            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var login = Request.Form["txtLogin"].ToString();
            var senha = Request.Form["txtSenha"].ToString();
            Logar(login, senha);
        }

        public void Logar(string login, string senha)
        {
            if (service.ValidaLogin(login, senha))
            {
                Session["Login"] = login;
                Response.Redirect("~/Documentos/Documento.aspx");
            }
            lblMsgErro.Text = "Informações de login/senha inválidos.";
            lblMsgErro.Visible = true;
        }
    }
}