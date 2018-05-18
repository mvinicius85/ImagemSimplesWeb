<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaIndexar.aspx.cs" Inherits="ImagemSimplesWeb.Documentos.ListaIndexar" EnableEventValidation="false" %>


<asp:Content ContentPlaceHolderID="ListaIndexar" runat="server">
    <div class="content">
        <div class="listaArquivos">
            <asp:Literal runat="server" ID="ArquivosIndexar">
       
            </asp:Literal>
        </div>
    </div>
</asp:Content>
