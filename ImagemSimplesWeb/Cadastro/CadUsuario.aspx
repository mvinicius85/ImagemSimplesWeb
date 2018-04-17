<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CadUsuario.aspx.cs" Inherits="ImagemSimplesWeb.Cadastro.CadUsuario" %>

<asp:Content ContentPlaceHolderID="CadUsuario" runat="server">
    <div class="TableUsuarios">
        <table id="tbUser">
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server" Text="Id: "></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblidUsuario"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server" Text="Codigo: "></asp:Label>
                </td>
                <td>

                    <asp:TextBox runat="server" ID="txtCodigo"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server" Text="Senha: "></asp:Label>
                </td>
                <td>

                    <asp:TextBox runat="server" ID="txtSenha"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server" Text="Nome: "></asp:Label>
                </td>
                <td>

                    <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server" Text="Departamento: "></asp:Label>
                </td>
                <td>

                    <asp:TextBox runat="server" ID="txtDepartamento"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server" Text="Cadastro: "></asp:Label>
                </td>
                <td>

                    <asp:TextBox runat="server" ID="txtCadastro"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server" Text="DataInicio: "></asp:Label>
                </td>
                <td>

                    <asp:TextBox runat="server" ID="txtDtInicio"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server" Text="Telefone: "></asp:Label>
                </td>
                <td>

                    <asp:TextBox runat="server" ID="txtTelefone"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server" Text="Residencial: "></asp:Label>
                </td>
                <td>

                    <asp:TextBox runat="server" ID="txtTelRes"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server" Text="Celular: "></asp:Label>
                </td>
                <td>

                    <asp:TextBox runat="server" ID="txtTelCel"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="cadCategoriaLabel">
                    <asp:Label runat="server" Text="Email: "></asp:Label>
                </td>
                <td>

                    <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick="btnSalvar_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="btnLimpar" Text="Limpar" /></td>
                <td>
                    <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
