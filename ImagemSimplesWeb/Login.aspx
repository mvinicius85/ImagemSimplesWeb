<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ImagemSimplesWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/css/Login.css" />
    <%-- <link rel="shortcut icon" type="image/x-icon" href="/Imagens/favicon.ico" />--%>


    <title>Imagem Simples</title>
    <style type="text/css">
        .txtLogin {
        }
    </style>
</head>
<body>

    <div class="mainLogin">
        <div class="LoginHeader">
            <div class="ImageLogo">
                <asp:Image runat="server" ImageUrl="~/Imagens/saudesimpleslogo.png" />
            </div>
        </div>
        <form id="formLogin" runat="server">
            <div class="Login">


                <%--                       <asp:Label runat="server" CssClass="lblLogin" Text="Login "></asp:Label><br />--%>

                <asp:TextBox runat="server" placeholder="Nome de Usuario" CssClass="txtDadosLogin" ID="txtLogin" Width="100%"></asp:TextBox>
                <br />

                <%--                            <asp:Label runat="server" CssClass="lblLogin" Text="Senha "></asp:Label><br />--%>

                <asp:TextBox runat="server" placeholder="Senha" CssClass="txtDadosLogin" ID="txtSenha" TextMode="Password" Width="100%"></asp:TextBox>

                <div>
                    <asp:Button ID="btnLogin" runat="server" Text="Entrar" OnClick="btnLogin_Click" CssClass="BtnLogin" />

                </div>
            </div>
        </form>

    </div>
    <div class="loginBottom">
        <p>OM30 - Todos os direitos reservados</p>
        <p>Imagem Simples</p>

    </div>


</body>
</html>
