<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Usuarios.aspx.cs" Inherits="ImagemSimplesWeb.Cadastro.Usuarios" %>

<asp:Content ContentPlaceHolderID="Usuarios" runat="server">
    <script>
        function ShowDivPesquisa() {
            var x = document.getElementById("DivPanelPesquisa");
            if (x.style.display === "block") {
                x.style.display = "none";
            } else {
                x.style.display = "block";
                //}
            }
        }
    </script>

    <div>
    </div>


    <div class="divcategoria">
        <asp:Button runat="server" ID="btnIncluir" Text="Incluir" OnClick="btnIncluir_Click" CssClass="btnIncluir" />
        <button type="button" onclick="ShowDivPesquisa()" class="btnShowDiv">Filtro</button>
        <div class="PanelPesquisa" id="DivPanelPesquisa">
            <table>
                <tr>
                    <td  class="tdText">
                        <asp:Label runat="server" >Nome:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  class="tdText">
                        <asp:Label runat="server" >Departamento:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDepartamento"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Button runat="server" ID="BtnPesquisar" CssClass="BtnPesquisar" Text="Pesquisar" OnClick="BtnPesquisar_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GridUsuarios" runat="server" AllowPaging="True"
            CssClass="GridCadastro" OnPageIndexChanging="GridUsuarios_PageIndexChanging"
            AutoGenerateColumns="false">

            <Columns>
                <asp:TemplateField HeaderText="ID" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="id_user" runat="server"
                            Text='<%# Bind("id_user") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Codigo" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="clie_codigo" runat="server"
                            Text='<%# Bind("codigo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nome" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="Nome" runat="server"
                            Text='<%# Bind("Nome") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Depto" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="Depto" runat="server"
                            Text='<%# Bind("Depto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="Data" runat="server"
                            Text='<%# Bind("Data") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data Inicio" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="DataInicio" runat="server"
                            Text='<%# Bind("DataInicio") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tel. 1" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="Tel1" runat="server"
                            Text='<%# Bind("Tel1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tel. 2" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="Tel2" runat="server"
                            Text='<%# Bind("Tel2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Tel. 3" SortExpression="FirstName" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="Tel3" runat="server"
                            Text='<%# Bind("Tel3") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:Label ID="Email" runat="server"
                            Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ativo" SortExpression="FirstName">
                    <ItemTemplate>
                        <asp:CheckBox ID="ativo" runat="server" Enabled="false"
                            Checked='<%# Bind("ativo") %>'></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="40">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ToolTip="Editar" ImageUrl="~/Imagens/icons8-no-edit-40.png" ID="BtnEdit" OnClick="BtnEdit_Click" CommandArgument='<%# Bind("id_User") %>' />

                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
