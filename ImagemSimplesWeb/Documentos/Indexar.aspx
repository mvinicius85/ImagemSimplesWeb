<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Indexar.aspx.cs" Inherits="ImagemSimplesWeb.Documentos.Indexar" %>

<asp:Content ContentPlaceHolderID="Indexar" runat="server">

    <script>
        function SalvarIndexacao() {
            var q = document.getElementById("qtdeatb");
            var atribs = "";
            for (var i = 1; i <= q.value; i++) {
                var x = document.getElementById("txt" + i);
                atribs = atribs + ";" + x.value;
                atribs[i] = x.value;
            }

            var idcateg = document.getElementById("idcateg").value;

            $.ajax({
                type: "POST",
                url: 'Indexar.aspx/SalvarIndexacao',
                data: "{atribs:'" + atribs + "', idcateg:'" + idcateg + "'}",
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                success: function () {
                    //window.open(data.d + '\\' + pdfname, '_blank');
                }
            });
        }
    </script>
    <div>
        <div class="IndexarPanelPdf" id="DivPanelPreview">
            <iframe id="pdfFrame" runat="server" src=""></iframe>
        </div>
        <asp:DropDownList runat="server" ID="ddlCategorias" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        <div>
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
