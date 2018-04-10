<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CadCategoria.aspx.cs" Inherits="ImagemSimplesWeb.Cadastro.CadCategoria" %>

<asp:Content ContentPlaceHolderID="CadCategoria" runat="server">

    <div class="divcadcategoria">
        <table>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server"  Text="Id: "></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblidCategoria"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server" Text="Dependencia: "></asp:Label>
                </td>
                <td>
                
                    <asp:DropDownList runat="server" ID="ddlMenus"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server" Text="Descrição: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDescricao"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server"  Text="Existe MDB: "></asp:Label>

                </td>
                <td>
                    <asp:CheckBox runat="server" ID="chkExisteMDB" />
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server"  Text="Caminho Imagens: "></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPathImagens"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td><asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick="btnSalvar_Click" /></td>
                <td><asp:Button runat="server" ID="btnLimpar" Text="Limpar" /></td>
                <td><asp:Button runat="server" ID="btnCancelar" Text="Cancelar" /></td>
            </tr>
        </table>
    </div>


</asp:Content>

