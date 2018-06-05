<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Indexar.aspx.cs" Inherits="ImagemSimplesWeb.Documentos.Indexar" %>

<asp:Content ContentPlaceHolderID="Indexar" runat="server">

    <script src="../javascript/indexar.js"></script>
    <div>
        <div class="MsgErro">
           <label id="lblMsgErro"></label>
        </div>
        <div class="IndexarPanelPdf" id="DivPanelPreview">
            <iframe id="pdfFrame" runat="server" src=""></iframe>
        </div>
        <div class="IndexarPanelIndices">
            <asp:DropDownList runat="server" ID="ddlCategorias" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            <table>
                <asp:Literal runat="server" ID="TableAtributos">
       
                </asp:Literal>
                <tr>
                    <td>

                        <button type="button" id="btnSalvar" class="BtnPesquisar" onclick="SalvarIndexacao()">Salvar</button>
                        <%--                        <asp:Button runat="server" CssClass="BtnPesquisar" ID="BtnSalvar" OnClick="BtnSalvar_Click" />--%>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
