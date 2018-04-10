﻿using ImagemSimplesWeb.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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
            service = container.GetInstance<ICadastroAppService>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var login = Request.Form["txtLogin"].ToString();
            var senha = Request.Form["txtSenha"].ToString();
            if (service.ValidaLogin(login,senha))
            {
                Session["Login"] = login;
                Response.Redirect("~/Documentos/Documento.aspx");
            }
        }
    }
}